using System.Collections.Generic;

namespace AdventureGame {
    public class Location : Container {
        public Dictionary<Directions, Location> Directions { get; protected set; }

        public Location(string name, string shortDesc, string longDesc, List<Item> items = null,
            List<Container> containers = null, Dictionary<Directions, Location> directions = null) : base(name,
                shortDesc, longDesc) {
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

            if(directions == null) {
                Directions = new Dictionary<Directions, Location>();
            }
            else {
                Directions = directions;
            }
        }
    }
}
