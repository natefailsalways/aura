﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Common.Constants;
using Common.Data;
using Common.Tools;
using Common.World;
using csscript;
using CSScriptLibrary;
using World.Tools;
using World.World;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace World.Scripting
{
	public class NPCManager
	{
		public readonly static NPCManager Instance = new NPCManager();
		static NPCManager() { }
		private NPCManager() { }

		private int _loadedNpcs, _cached;

		public void LoadNPCs()
		{
			Logger.Info("Loading NPCs...");

			_loadedNpcs = _cached = 0;

			// NPCs
			var listPath = Path.Combine(Path.Combine(WorldConf.ScriptPath, "npc"), "npclist.txt");
			var npcListContents = new List<string>();

			if (File.Exists(listPath))
			{
				try
				{
					npcListContents = FileReader.GetAllLines(listPath);
				}
				catch (Exception ex)
				{
					Logger.Warning("Unable to fully parse " + listPath + ". Error: " + ex.Message);
				}
			}
			else
			{
				Logger.Warning("Unable to find NPC list '" + listPath + "'.");
			}

			var scriptFiles = npcListContents.ToArray();

			List<string> regulars = new List<string>();

			foreach (var line in scriptFiles)
			{
				if (line.StartsWith("virtual:"))
				{
					LoadNPC(new NPCLoadInfo(line.Replace("virtual:", "").Trim(), true));
				}
				else
					regulars.Add(line);
			}

			Task[] tasks = new Task[regulars.Count];

			for (int i = 0; i < regulars.Count; i++)
			{
				tasks[i] = Task.Factory.StartNew(LoadNPC, new NPCLoadInfo(regulars[i], false));
			}

			Task.WaitAll(tasks);

			Logger.Info("Done loading " + _loadedNpcs + " NPCs");
			if (!WorldConf.DisableScriptCaching)
				Logger.Info("Cached " + _cached + " NPC scripts.");
		}

		private class NPCLoadInfo
		{
			public string Path;
			public bool Virt;
			public NPCLoadInfo(string p, bool v)
			{
				Path = p;
				Virt = v;
			}
		}

		/// <summary>
		/// Loads the script file at the given path and adds the NPC to the world.
		/// </summary>
		/// <param name="path"></param>
		private void LoadNPC(object args)
		{
			NPCLoadInfo load = args as NPCLoadInfo;
			load.Path = Path.Combine(WorldConf.ScriptPath, "npc", load.Path);
			try
			{
				var script = this.LoadScript(load.Path).CreateObject("*") as NPCScript;
				script.ScriptPath = load.Path;
				script.ScriptName = Path.GetFileName(load.Path);
				if (!load.Virt)
				{
					var npc = new MabiNPC();
					npc.Script = script;
					npc.ScriptPath = load.Path;
					script.NPC = npc;
					script.LoadType = NPCLoadType.Real;
					script.OnLoad();
					script.OnLoadDone();

					// Only load defaults with race set.
					if (npc.Race != 0 && npc.Race != uint.MaxValue)
						npc.LoadDefault();

					WorldManager.Instance.AddCreature(npc);
				}
				else
				{
					script.LoadType = NPCLoadType.Virtual;
				}

				Interlocked.Increment(ref _loadedNpcs);
			}
			catch (CompilerException ex)
			{
				var errors = ex.Data["Errors"] as CompilerErrorCollection;

				Logger.Error("In " + load.Path + ":");
				foreach (CompilerError err in errors)
					Logger.Error("  Line " + err.Line.ToString() + ": " + err.ErrorText);
			}
			catch (Exception ex)
			{
				try
				{
					File.Delete(this.GetCompiledPath(load.Path));
				}
				catch { }
				Logger.Error("While processing: " + load.Path + " ... " + ex.Message);
			}
		}

		/// <summary>
		/// Adds "cache" to the given path.
		/// Example: data/script/folder/script.cs > data/script/cache/folder/script.cs
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private string GetCompiledPath(string filePath)
		{
			return Path.ChangeExtension(filePath.Replace(WorldConf.ScriptPath, Path.Combine(WorldConf.ScriptPath, "cache")), ".compiled");
		}

		/// <summary>
		/// Loads the given script from the cache, or recaches it,
		/// if necessary. Returns script assembly.
		/// </summary>
		/// <param name="scriptPath"></param>
		/// <returns></returns>
		public Assembly LoadScript(string scriptPath)
		{
			var compiledPath = this.GetCompiledPath(scriptPath);

			Assembly asm;
			if (!WorldConf.DisableScriptCaching && File.Exists(compiledPath) && File.GetLastWriteTime(compiledPath) >= File.GetLastWriteTime(scriptPath))
			{
				asm = Assembly.LoadFrom(compiledPath);
			}
			else
			{
				asm = CSScript.LoadCode(this.ReadScriptFile(scriptPath));
				if (!WorldConf.DisableScriptCaching)
				{
					try
					{
						if (File.Exists(compiledPath))
							File.Delete(compiledPath);
						else
							Directory.CreateDirectory(Path.GetDirectoryName(compiledPath));

						File.Copy(asm.Location, compiledPath);

						Interlocked.Increment(ref _cached);
					}
					catch (UnauthorizedAccessException)
					{
						// Thrown if file can't be copied. Happens if script was
						// initially loaded from cache.
					}
					catch (Exception ex)
					{
						Logger.Warning(ex.Message);
					}
				}
			}

			return asm;
		}

		private string ReadScriptFile(string filePath)
		{
			var file = File.ReadAllText(filePath);
			var sb = new StringBuilder();

			// Usings
			{
				// Default:
				// using System;
				// using Common.Constants;
				// using Common.World;
				// using World.Network;
				// using World.Scripting;
				// using World.World;

				//if (!Regex.Match(file, @"(^|;)\s*using System;").Success) sb.Append("using System;");
				//if (!Regex.Match(file, @"(^|;)\s*using Common.Constants;").Success) sb.Append("using Common.Constants;");
				//if (!Regex.Match(file, @"(^|;)\s*using Common.World;").Success) sb.Append("using Common.World;");
				//if (!Regex.Match(file, @"(^|;)\s*using World.Network;").Success) sb.Append("using World.Network;");
				//if (!Regex.Match(file, @"(^|;)\s*using World.Scripting;").Success) sb.Append("using World.Scripting;");
				//if (!Regex.Match(file, @"(^|;)\s*using World.World;").Success) sb.Append("using World.World;");
			}

			// Append the actual file
			sb.Append(file);

			return sb.ToString();
		}

		public void LoadSpawns()
		{
			int count = 0;
			foreach (var spawnInfo in MabiData.SpawnDb.Entries)
			{
				count += this.Spawn(spawnInfo);
			}

			Logger.Info("Spawned " + count.ToString() + " monsters.");
		}

		public void Spawn(uint spawnId, int amount = 0)
		{
			var info = MabiData.SpawnDb.Find(spawnId);
			if (info == null)
			{
				Logger.Warning("Unknown spawn Id '" + spawnId.ToString() + "'.");
				return;
			}

			this.Spawn(info, amount);
		}

		public int Spawn(SpawnInfo info, int amount = 0)
		{
			var result = 0;

			var rand = RandomProvider.Get();

			var raceInfo = MabiData.RaceDb.Find(info.RaceId);
			if (raceInfo == null)
			{
				Logger.Warning("Race not found: " + info.RaceId.ToString());
				return 0;
			}

			string aiFilePath = null;
			if (!string.IsNullOrEmpty(raceInfo.AI))
			{
				aiFilePath = Path.Combine(WorldConf.ScriptPath, "ai", raceInfo.AI + ".cs");
				if (!File.Exists(aiFilePath))
				{
					Logger.Warning("AI script '" + raceInfo.AI + ".cs' couldn't be found.");
					aiFilePath = null;
				}
			}

			if (amount == 0)
				amount = info.Amount;

			for (int i = 0; i < amount; ++i)
			{
				var monster = new MabiNPC();
				monster.SpawnId = info.Id;
				monster.Name = raceInfo.Name;
				var loc = info.GetRandomSpawnPoint(rand);
				monster.SetLocation(info.Region, loc.X, loc.Y);
				monster.ColorA = raceInfo.ColorA;
				monster.ColorB = raceInfo.ColorB;
				monster.ColorC = raceInfo.ColorC;
				monster.Height = raceInfo.Size;
				monster.LifeMaxBase = raceInfo.Life;
				monster.Life = raceInfo.Life;
				monster.Race = raceInfo.Id;
				monster.BattleExp = raceInfo.Exp;
				monster.Direction = (byte)rand.Next(256);
				monster.State &= ~CreatureStates.GoodNpc; // Use race default?
				monster.GoldMin = raceInfo.GoldMin;
				monster.GoldMax = raceInfo.GoldMax;
				monster.Drops = raceInfo.Drops;

				foreach (var skill in raceInfo.Skills)
				{
					monster.Skills.Add(new MabiSkill(skill.SkillId, skill.Rank, monster.Race));
				}

				monster.LoadDefault();

				if (aiFilePath != null)
				{
					monster.AIScript = this.LoadScript(aiFilePath).CreateObject("*") as AIScript;
					monster.AIScript.Creature = monster;
					monster.AIScript.OnLoad();
					monster.AIScript.Activate(0); // AI is intially active
				}

				WorldManager.Instance.AddCreature(monster);
				result++;
			}

			return result;
		}
	}
}
