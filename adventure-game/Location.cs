using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game {
    public class Location : Container {
        public Dictionary<Directions, Location> Directions { get; protected set; }
        
        public Location(string name, string shortDesc, string longDesc,
            List<Item> items = null, List<Container> containers = null,
            Dictionary<Directions, Location> directions = null) :
            base(name, shortDesc, longDesc, items, containers) {
            Directions = (directions != null ? directions : new Dictionary<Directions, Location>());
        }
    }
}
