﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see licence.txt in the main folder

using System;

namespace Aura.Shared.Const
{
	[Flags]
	public enum CreatureStates : uint
	{
		Initialized = 0x00000001,
		Dead = 0x00000002,
		SitDown = 0x00000004,
		Spawned = 0x00000008,
		EverEnterWorld = 0x00000010,
		NorespawnPenalty = 0x00000020,
		InventoryViewDisable = 0x00000080,
		PetFinishMode = 0x00000100,
		FreeRebirth = 0x00000200,
		JustRebirth = 0x00000400,
		LevelResetRebirth = 0x00000800,
		EnableCommonPvp = 0x00001000,
		JournalVisible = 0x00002000,
		TransformCutsceneSkip = 0x00004000,
		EscortNpc = 0x02000000,
		UntouchableNpc = 0x08000000,
		InstantNpc = 0x10000000,
		GoodNpc = 0x20000000,
		NamedNpc = 0x40000000,
		Npc = 0x80000000,
	}

	[Flags]
	public enum CreatureStatesEx : uint
	{
		DefenceBonus = 0x00000001,
		WhisperDisable = 0x00000002,
		FakeDeath = 0x00000004,
		Cloaking = 0x00000008,
		ThrowingStone = 0x00000010,
		SubRace = 0x00000020,
		NotDown = 0x00000040,
		NoHitDelay = 0x00000080,
		Hibernation = 0x00000100,
		SummonedByGiant = 0x00000200,
		DisableMeleeAttack = 0x00000400,
		SyncFrameworkEffect = 0x00000800,
		CloakingAfterRevival = 0x00001000,
		Bubble = 0x00002000,
		CaptureTheFlagMember = 0x00004000,
		CaptureTheFlagRedteam = 0x00008000,
		CaptureTheFlagHasflag = 0x00010000,
		CaptureTheFlagRedflag = 0x00020000,
		CaptureTheFlagFreezed = 0x00040000,
		WaterBalloonBattleMember = 0x00080000,
		WaterBalloonBattleRed = 0x00100000,
		WearShadowdungeonMask = 0x00400000,
		RoyalAlchemist = 0x00800000,
		TailingClaudius = 0x01000000,
		UseUmbrella = 0x02000000,
		ThrowingGold = 0x04000000,
		ZombieWalk = 0x08000000,
	}

	public enum Stat : byte
	{
		Name = 0,
		Title = 1,
		EngTitle = 2,
		Type = 3,
		SkinColor = 4,
		EyeType = 5,
		EyeColor = 6,
		MouthType = 7,
		State = 8,
		StateEx = 9,
		Height = 10,
		Weight = 11,
		Upper = 12,
		Lower = 13,
		RegionId = 14,
		PositionX = 15,
		PositionY = 16,
		Direction = 17,
		BattleState = 18,
		WeaponSet = 19,
		Extra1 = 20,
		Extra2 = 21,
		Extra3 = 22,
		CombatPower = 23,
		MotionType = 24,
		Life = 25,
		LifeInjured = 26,
		LifeMax = 27,
		LifeMaxMod = 28,
		Mana = 29,
		ManaMax = 30,
		ManaMaxMod = 31,
		Stamina = 32,
		StaminaMax = 33,
		StaminaMaxMod = 34,
		Food = 35,
		FoodMinRatio = 36,
		Level = 37,
		LevelTotal = 38,
		LevelMax = 39,
		RebirthCount = 40,
		LifeTimeSkill = 41,
		Experience = 42,
		Age = 43,
		Str = 44,
		StrMod = 45,
		Dex = 46,
		DexMod = 47,
		Int = 48,
		IntMod = 49,
		Will = 50,
		WillMod = 51,
		Luck = 52,
		LuckMod = 53,
		LifeMaxByFood = 54,
		ManaMaxByFood = 55,
		StaminaMaxByFood = 56,
		StrengthByFood = 57,
		DexterityByFood = 58,
		IntelligenceByFood = 59,
		WillByFood = 60,
		LuckByFood = 61,
		AbilityPoints = 62,
		AttackMinBase = 63,
		AttackMinMod = 64,
		AttackMaxBase = 65,
		AttackMaxMod = 66,
		WattackMinBase = 67,
		WattackMinMod = 68,
		WattackMaxBase = 69,
		WattackMaxMod = 70,
		LeftAttackMinMod = 71,
		LeftAttackMaxMod = 72,
		RightAttackMinMod = 73,
		RightAttackMaxMod = 74,
		LeftWattackMinMod = 75,
		LeftWattackMaxMod = 76,
		RightWattackMinMod = 77,
		RightWattackMaxMod = 78,
		LeftCriticalMod = 79,
		RightCriticalMod = 80,
		LeftRateMod = 81,
		RightRateMod = 82,
		MagicDefenseMod = 83,
		MagicAttackMod = 84,
		MeleeAttackRateMod = 85,
		RangeAttackRateMod = 86,
		CriticalBase = 87,
		CriticalMod = 88,
		ProtectBase = 89,
		ProtectMod = 90,
		DefenseBase = 91,
		DefenseMod = 92,
		RateBase = 93,
		RateMod = 94,
		Rank1 = 95,
		Rank2 = 96,
		Score = 97,
		AttackMinBaseMod = 98,
		AttackMaxBaseMod = 99,
		WattackMinBaseMod = 100,
		WattackMaxBaseMod = 101,
		CriticalBaseMod = 102,
		ProtectBaseMod = 103,
		DefenseBaseMod = 104,
		RateBaseMod = 105,
		MeleeAttackMinBaseMod = 106,
		MeleeAttackMaxBaseMod = 107,
		MeleeWattackMinBaseMod = 108,
		MeleeWattackMaxBaseMod = 109,
		RangeAttackMinBaseMod = 110,
		RangeAttackMaxBaseMod = 111,
		RangeWattackMinBaseMod = 112,
		RangeWattackMaxBaseMod = 113,
		PoisonBase = 114,
		PoisonMod = 115,
		PoisonImmuneBase = 116,
		PoisonImmuneMod = 117,
		PoisonDamageRatio1 = 118,
		PoisonDamageRatio2 = 119,
		EnchantCombatPowerMod = 120,
		CumulateStr = 121,
		CumulateDex = 122,
		CumulateInt = 123,
		CumulateWill = 124,
		CumulateLuck = 125,
		CumulateHeight = 126,
		CumulateFatness = 127,
		CumulateUpper = 128,
		CumulateLower = 129,
		CumulateLife = 130,
		CumulateMana = 131,
		CumulateStamina = 132,
		Toxic = 133,
		ToxicDrunkenTime = 134,
		ToxicStr = 135,
		ToxicInt = 136,
		ToxicDex = 137,
		ToxicWill = 138,
		ToxicLuck = 139,
		LastTown = 140,
		LastDungeon = 141,
		ExploLevel = 142,
		ExploMaxKeyLevel = 143,
		ExploCumLevel = 144,
		ExploExp = 145,
		DiscoverCount = 146,
		ConditionStr = 147,
		ConditionInt = 148,
		ConditionDex = 149,
		ConditionWill = 150,
		ConditionLuck = 151,
		ElementPhysical = 152,
		ElementLightning = 153,
		ElementFire = 154,
		ElementIce = 155,
		BareAttackMin = 156,
		BareAttackMax = 157,
		BareWattackMin = 158,
		BareWattackMax = 159,
		BareCritical = 160,
		BareRate = 161,
	}

	public enum CreatureConditionA : ulong
	{
		Poisoned = 0x0000000000000001,
		Deadly = 0x0000000000000002,
		PotionPoisoning = 0x0000000000000004,
		Numb = 0x0000000000000008,
		Silence = 0x0000000000000010,
		Petrified = 0x0000000000000020,
		Coward = 0x0000000000000040,
		Outraged = 0x0000000000000080,
		Confused = 0x0000000000000100,
		Combat2xExp = 0x0000000000000200,
		Slow = 0x0000000000000400,
		Luck = 0x0000000000000800,
		Misfortune = 0x0000000000001000,
		LeadersBlessing = 0x0000000000002000,
		Explode1 = 0x0000000000004000,
		Explode2 = 0x0000000000008000,
		Mirage = 0x0000000000010000,
		Weak = 0x0000000000020000,
		PVPPenalty = 0x0000000000040000,
		Lethargic = 0x0000000000080000,
		CancelDarkKnight = 0x0000000000100000,
		Camouflage = 0x0000000000200000,
		Blessed = 0x0000000000400000,
		Invisible = 0x0000000000800000,
		NoTrade = 0x0000000001000000,
		Following = 0x0000000002000000,
		ChatBanned = 0x0000000004000000,
		ViewCutScene = 0x0000000008000000,
		Ensemble = 0x0000000010000000,
		SharpAiming = 0x0000000020000000,
		FastCasting = 0x0000000040000000,
		Weaken = 0x0000000080000000,
		MushroomCookie = 0x0000000100000000,
		CryFood = 0x0000000200000000,
		CrazyFood = 0x0000000400000000,
		SelfPraiseFood = 0x0000000800000000,
		HeartFood = 0x0000001000000000,
		PoisonImmune = 0x0000002000000000,
		PetrificationImmunity = 0x0000004000000000,
		ManaUsageReduction = 0x0000008000000000,
		StaminaUsageReduction = 0x0000010000000000,
		ExplosiveImmunity = 0x0000020000000000,
		StompImmunity = 0x0000040000000000,
		ManaUsageIncrease = 0x0000080000000000,
		StaminaUsageIncrease = 0x0000100000000000,
		ShareFood = 0x0000200000000000,
		IceShield = 0x0000400000000000,
		FireShield = 0x0000800000000000,
		LightningShield = 0x0001000000000000,
		NaturalShield = 0x0002000000000000,
		MoveSlow = 0x0004000000000000,
		FastGathering = 0x0008000000000000,
		Charge = 0x0010000000000000,
		AttackSpeed = 0x0020000000000000,
		Moonlight = 0x0040000000000000,
		SulfurPoison = 0x0080000000000000,
		Burn = 0x0100000000000000,
		Freeze = 0x0200000000000000,
		StarFood = 0x0400000000000000,
		ManaShield = 0x0800000000000000,
		CherryTree = 0x1000000000000000,
		Boose = 0x2000000000000000,
		FastCasting2 = 0x4000000000000000,
		WeaponAttackBoost = 0x8000000000000000,
	}

	public enum CreatureConditionB : ulong
	{
		Transparent = 0x0000000000000001,
		CombatExpPlus1_1 = 0x0000000000000002,
		CombatExpPlus2 = 0x0000000000000004,
		Bewildered = 0x0000000000000008,
		ElephantShower = 0x0000000000000010,
		Curse = 0x0000000000000020,
		Blind = 0x0000000000000040,
		Ice = 0x0000000000000080,
		ProductionRateChange = 0x0000000000000100,
		ItemProfInc = 0x0000000000000200,
		AlchemyCloud = 0x0000000000000400,
		FailedBotCheck = 0x0000000000000800,
		SnowStorm = 0x0000000000001000,
		Doppelganger = 0x0000000000002000,
		Demigod = 0x0000000000004000,
		DoppelgangerLaugh = 0x0000000000008000,
		DoppelgangerPain = 0x0000000000010000,
		ValentineHappy = 0x0000000000020000,
		ValentineUnhappy = 0x0000000000040000,
		FashionShow = 0x0000000000080000,
		LargeUpper = 0x0000000000100000,
		DumbTalking = 0x0000000000200000,
		LargeLower = 0x0000000000400000,
		VeryBig = 0x0000000000800000,
		VerySmall = 0x0000000001000000,
		Blessed = 0x0000000002000000,
		Outraged = 0x0000000004000000,
		MiniPotion = 0x0000000008000000,
		NoConsume = 0x0000000010000000,
		StoneBarrier = 0x0000000020000000,
		Discharge = 0x0000000040000000,
		Stand = 0x0000000080000000,
		LifeExpInc = 0x0000000100000000,
		CombatExpInc = 0x0000000200000000,
		MagicExpInc = 0x0000000400000000,
		AlchemyExpInc = 0x0000000800000000,
		NameColorChange = 0x0000001000000000,
		TowerCylinder = 0x0000002000000000,
		DemiStrInc = 0x0000004000000000,
		DemiDexInc = 0x0000008000000000,
		DemiWillInc = 0x0000010000000000,
		DemiLuckInc = 0x0000020000000000,
		DemiIntInc = 0x0000040000000000,
		DemiFuryInc = 0x0000080000000000,
		DemiSpearInc = 0x0000100000000000,
		DemiShadowInc = 0x0000200000000000,
		DemiDurationInc = 0x0000400000000000,
		DemiCooldownDec = 0x0000800000000000,
		DemiBrionacDmgInc = 0x0001000000000000,
		DemiBrionacCritInc = 0x0002000000000000,
		BardInc = 0x0004000000000000,
		SpeedInc = 0x0008000000000000,
		DemiImmune = 0x0010000000000000,
		HeightChange = 0x0020000000000000,
		RavenAttack = 0x0040000000000000,
		NuadhaPhase = 0x0080000000000000,
		MountAttack = 0x0100000000000000,
		StatsDec = 0x0200000000000000,
		ShadowBonus = 0x0400000000000000,
		ItemDropInc = 0x0800000000000000,
		ItemDropInc2 = 0x1000000000000000,
		FishDropInc = 0x2000000000000000,
		FishDropInc2 = 0x4000000000000000,
		ChatColorChange = 0x8000000000000000,
	}

	public enum CreatureConditionC : ulong
	{ }

	public enum CreatureConditionD : ulong
	{ }

	public struct CreatureCondition
	{
		public CreatureConditionA A;
		public CreatureConditionB B;
		public CreatureConditionC C;
		public CreatureConditionD D;

		public void Clear()
		{
			A = 0;
			B = 0;
			C = 0;
			D = 0;
		}
	}
}
