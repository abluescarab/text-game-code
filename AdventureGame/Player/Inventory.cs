using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame {
    public class Inventory {
        public List<Item> Items { get; set; }

        public Inventory() {
            Items = new List<Item>();
        }

        public Inventory(Item[] items) {
            Items = new List<Item>(items);
        }

        public Inventory(List<Item> items) {
            Items = items;
        }

        public void Show() {
            Console.WriteLine("Your inventory contains:");

            foreach(Item item in Items) {
                Console.WriteLine(item.Name);
            }
        }
    }
}
