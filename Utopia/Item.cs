using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utopia {
	public class Item {
		public virtual int UseItem() { return 0; }
		public virtual string GetName() { return null; }
		
		/// <summary>
		/// Get item information.
		/// </summary>
		/// <returns>Item stats and information.</returns>
		public virtual string[] GetInfo() {
			string[] info = { Equipped.ToString(), Name, Desc, Strength.ToString(), Dex.ToString(), Int.ToString(), Def.ToString(), Hp.ToString() };

			return info;
		}

		/// <summary>
		/// Equip an item (weapon or armor).
		/// </summary>
		public void EquipItem() {
			if(Equipped) {
				if(Strength > 0) Program.player.ChangeStat(Player.Stats.STRENGTH, Strength);
				if(Dex > 0)      Program.player.ChangeStat(Player.Stats.DEXTERITY, Dex);
				if(Int > 0)      Program.player.ChangeStat(Player.Stats.INTELLIGENCE, Int);
				if(Def > 0)      Program.player.ChangeStat(Player.Stats.DEFENSE, Def);
				if(Hp > 0)       Program.player.ChangeStat(Player.Stats.HEALTH, Hp);
			}
			else {
				if(Strength > 0) Program.player.ChangeStat(Player.Stats.STRENGTH, -Strength);
				if(Dex > 0)      Program.player.ChangeStat(Player.Stats.DEXTERITY, -Dex);
				if(Int > 0)      Program.player.ChangeStat(Player.Stats.INTELLIGENCE, -Int);
				if(Def > 0)      Program.player.ChangeStat(Player.Stats.DEFENSE, -Def);
				if(Hp > 0)       Program.player.ChangeStat(Player.Stats.HEALTH, -Hp);
			}

			Equipped = !Equipped;
		}

		public static int newID = 0; // sets unique ID for every item
		public int ID        { get; set; }
		public string Name   { get; set; }
		public string Type   { get; set; }
		public string Desc   { get; set; }
		public int Strength  { get; set; }
		public int Dex       { get; set; }
		public int Int       { get; set; }
		public int Def       { get; set; }
		public int Hp        { get; set; }
		public int Buy       { get; set; }
		public double Weight { get; set; }

		public bool Equipped = false;
	}

	class Weapon : Item {
		public Weapon(string cName, string cDesc, int cStrength, int cDex, int cInt, int cDef, int cHp, int cBuy, double cWeight) {
			ID       = newID++;
			Name     = cName;
			Desc     = cDesc;
			Strength = cStrength;
			Dex      = cDex;
			Int      = cInt;
			Def      = cDef;
			Hp       = cHp;
			Buy      = cBuy;
			Weight   = cWeight;
		}
	}

	class Armor : Item {
		public Armor(string cName, string cDesc, int cStrength, int cDex, int cInt, int cDef, int cHp, int cBuy, double cWeight) {
			ID       = newID++;
			Name     = cName;
			Desc     = cDesc;
			Strength = cStrength;
			Dex      = cDex;
			Int      = cInt;
			Def      = cDef;
			Hp       = cHp;
			Buy      = cBuy;
			Weight   = cWeight;
		}
	}

	class Potion : Item {
		private int potionHealth;

		public Potion() {
			potionHealth = 10;
		}

		public Potion(int amount) {
			potionHealth = amount;
		}

		public override string[] GetInfo() {
			string[] info = {""};

			return info;
		}
	}
}
