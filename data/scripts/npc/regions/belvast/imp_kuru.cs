using Aura.Shared.Const;
using System;
using Aura.World.Network;
using Aura.World.Scripting;
using Aura.World.World;

public class Imp_kuruScript : NPCScript
{
	public override void OnLoad()
	{
		base.OnLoad();
		SetName("_imp_kuru");
		SetRace(321);
		SetBody(height: 1f, fat: 1f, upper: 1f, lower: 1f);
		SetFace(skin: 21, eye: 3, eyeColor: 7, lip: 2);

		SetColor(0x4C655C, 0xAB8E8E, 0x35503D);



		SetLocation(region: 4005, x: 33488, y: 40812);

		SetDirection(104);
		SetStand("chapter4/monster/anim/imp/imp_c4_npc_diet");

		Phrases.Add("*Pants* Oh...this is hard.");
		Phrases.Add("Flabby stomach...away with you!");
		Phrases.Add("I can't become fat, like the Ogres!");
		Phrases.Add("One-two, one-two!");
		Phrases.Add("One-two, one-two... Gotta get buff!");
	}
}
