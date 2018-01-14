using System.Collections.Generic;

namespace adventure_game {
    public class Container : Item {
        public List<Item> Items { get; protected set; }
        public List<Container> Containers { get; protected set; }

        public Container(string name, string shortDesc, string longDesc,
            List<Item> items = null, List<Container> containers = null) :
            base(name, shortDesc, longDesc) {
            Items = (items != null ? items : new List<Item>());
            Containers = (containers != null ? containers : new List<Container>());
        }
    }
}
