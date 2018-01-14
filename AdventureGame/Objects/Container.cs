using System.Collections.Generic;

namespace AdventureGame {
    public class Container : GameObject {
        public List<Item> Items { get; protected set; }
        public List<Container> Containers { get; protected set; }
        
        public Container(string name, string shortDesc, string longDesc, List<Item> items = null, 
            List<Container> containers = null) : base(name, shortDesc, longDesc) {
            if(items == null) {
                Items = new List<Item>();
            }
            else {
                Items = items;
            }

            if(containers == null) {
                Containers = new List<Container>();
            }
            else {
                Containers = containers;
            }
        }
    }
}
