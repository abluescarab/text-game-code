using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utopia {
	class Program {
		// list to store all game items
		public static List<Item> items = new List<Item>();
		// list to store all inventory items
		public static List<Item> inventory = new List<Item>();
		// create an instance of the player class
		public static Player player = new Player();
		// create a blank string for console input
		public static string input = "";

		static void Main(string[] args) {
			InitializeAllItems();

			Console.WriteLine(@"
     _    _ _______ ____  _____ _____          
    | |  | |__   __/ __ \|  __ \_   _|   /\
    | |  | |  | | | |  | | |__) || |    /  \
    | |  | |  | | | |  | |  ___/ | |   / /\ \
    | |__| |  | | | |__| | |    _| |_ / ____ \
     \____/   |_|  \____/|_|   |_____/_/    \_\
									
			");

			Console.WriteLine("Welcome to Utopia. Press any key to begin.");

			Console.ReadKey();



			InitializeInventory();
		}

		#region Initialization Functions
		/// <summary>
		/// Start the player with basic equipment based on their class.
		/// </summary>
		private static void InitializeInventory() {
			
		}

		/// <summary>
		/// Read all items from items.json and store them in the items list.
		/// </summary>
		private static void InitializeAllItems() {
			using(StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "items.json")) {
				string text = sr.ReadToEnd();
				RootObject root = JsonConvert.DeserializeObject<RootObject>(text);

				foreach(Item item in root.Items) {
					switch(item.Type) {
						case "Weapon":
							items.Add(new Weapon(item.Name, item.Desc, item.Strength, item.Dex, item.Int, item.Def, item.Hp, item.Buy, item.Weight));
							break;
						case "Armor":
							items.Add(new Armor(item.Name, item.Desc, item.Strength, item.Dex, item.Int, item.Def, item.Hp, item.Buy, item.Weight));
							break;
						case "Potion":
							//items.Add(new Potion(item.iName, item.iDesc, item.iStr, item.iDex, item.iInt, item.iDef, item.iHP, item.iBuy, item.iWeight));
							break;
						default:
							break;
					}
				}
			}
		}
		#endregion

		#region Inventory Functions
		/// <summary>
		/// Add an item to the inventory.
		/// </summary>
		/// <param name="ID">The item ID.</param>
		private static void AddItem(int ID) {
			inventory.Add(items.Find(item => item.ID == ID));
		}

		/// <summary>
		/// Remove (drop) an item from the inventory.
		/// </summary>
		/// <param name="ID">The item ID.</param>
		private static void DropItem(int ID) {
			inventory.Remove(items.Find(item => item.ID == ID));
		}
		#endregion

		#region Printing Functions
		/// <summary>
		/// Wait for input from the user.
		/// </summary>
		private static void Input() {
			Console.Write("> ");
			input = Console.ReadLine();
		}

		/// <summary>
		/// Pause before continuing.
		/// </summary>
		private static void Pause() {
			Console.WriteLine("(Press any key to continue...)");
			Console.ReadKey(true);
		}

		/// <summary>
		/// Print a specified amount of dashes (for formatting, generally).
		/// </summary>
		/// <param name="amount">The amount of dashes to print.</param>
		/// <returns>The amount of dashes to print.</returns>
		public static string PrintDashes(int amount) {
			string dashes = "";

			for(int i = 0; i < amount; i++) {
				dashes += "-";
			}

			return dashes;
		}

		/// <summary>
		/// Simulates a typing effect.
		/// </summary>
		/// <param name="content">The string to type.</param>
		/// <param name="newline">Whether or not to incude a new line at the end.</param>
		private static void Type(string content, bool newline) {
			int length = content.Length;

			System.Threading.Thread.Sleep(75);

			for(int i = 0; i < length; i++) {
				char c = content[i];
				Console.Write(c);
				System.Threading.Thread.Sleep(65);
			}

			if(newline) {
				Console.Write("\n");
			}
		}
		#endregion
	}
}
