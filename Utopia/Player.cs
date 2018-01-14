using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utopia {
	class Player {
		public enum Stats  { STRENGTH, DEXTERITY, INTELLIGENCE, DEFENSE, HEALTH };
		public enum Gender { FEMALE, MALE };
		public enum Race   { HUMAN, DWARF, ELF, GNOME, ORC, GOBLIN, TROLL };
		public enum Class  { WARRIOR, RANGER, MAGE };
		
		private string pName;
		private int    pStrength, pDex, pInt, pDef, pHp, pMoney,
					   pLevel, pExperience;
		private double pWeight, pMaxWeight;
		private Gender pGender;
		private Race   pRace;
		private Class  pClass;

		// constructor
		public Player() {
			pName = "Player";
			pStrength  = 0;
			pDex       = 0;
			pInt       = 0;
			pDef       = 0;
			pHp        = 100;
			pMoney     = 0;
			pWeight    = 0.0;
			pMaxWeight = 0.0;

			pGender    = Gender.MALE;
			pRace      = Race.HUMAN;
			pClass     = Class.WARRIOR;
		}

		/*public Player(string cName, Gender cGender, Race cRace, Class cClass, int cStrength, int cDex, int cInt, int cDef, int cHp, int cMoney, double cWeight, double cMaxWeight) {
			pName      = cName;
			pStrength  = cStrength;
			pDex       = cDex;
			pInt       = cInt;
			pDef       = cDef;
			pHp        = cHp;
			pMoney     = cMoney;
			pWeight    = cWeight;
			pMaxWeight = cMaxWeight;

			pGender    = cGender;
			pRace      = cRace;
			pClass     = cClass;
		}*/

		#region Accessors
		public string GetName() {
			return pName;
		}

		public Gender GetGender() {
			return pGender;
		}

		public Race GetRace() {
			return pRace;
		}

		public Class GetClass() {
			return pClass;
		}

		public int GetStat(Stats stat) {
			switch(stat) {
				case Stats.STRENGTH:
					return pStrength;
				case Stats.DEXTERITY:
					return pDex;
				case Stats.INTELLIGENCE:
					return pInt;
				case Stats.DEFENSE:
					return pDef;
				case Stats.HEALTH:
					return pHp;
				default:
					// the program broke (this should never happen)
					return -1;
			}
		}

		public int GetMoney() {
			return pMoney;
		}

		public double GetWeight() {
			return pWeight;
		}

		public double GetMaxWeight() {
			return pMaxWeight;
		}

		public int GetLevel() {
			return pLevel;
		}
		#endregion

		#region Change Values
		public void ChangeName(string cName) {
			pName = cName;
		}

		public void ChangeGender(Gender cGender) {
			pGender = cGender;
		}

		public void ChangeRace(Race cRace) {
			pRace = cRace;
		}

		public void ChangeClass(Class cClass) {
			pClass = cClass;
		}

		public void ChangeStat(Stats cStat, int amount) {
			switch(cStat) {
				case Stats.STRENGTH:
					pStrength += amount;
					break;
				case Stats.DEXTERITY:
					pDex += amount;
					break;
				case Stats.INTELLIGENCE:
					pInt += amount;
					break;
				case Stats.DEFENSE:
					pDef += amount;
					break;
				case Stats.HEALTH:
					pHp += amount;
					break;
				default:
					break;
			}
		}

		public void ChangeMoney(int amount) {
			pMoney += amount;
		}

		public void ChangeWeight(double amount) {
			pWeight += amount;
		}

		public void ChangeMaxWeight(double amount) {
			pMaxWeight += amount;
		}

		public void ChangeExperience(int amount) {
			pExperience += amount;
		}

		public void ChangeLevel() {
			pLevel++;
		}
		#endregion
	}
}
