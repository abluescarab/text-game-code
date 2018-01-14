using System;

namespace AdventureGame {
    public class Item : GameObject {
        public delegate string[] UseHandler(params string[] args);
        public UseHandler Use;

        public Item(string name, string shortDesc, string longDesc, UseHandler useMethod) : base(name, shortDesc, 
            longDesc) {
            Use = useMethod;
        }
    }
}
