using System;

namespace AdventureGame {
    public class GameObject {
        public uint ID { get; protected set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public bool Seen { get; set; }

        public GameObject(string name, string shortDesc, string longDesc) {
            Name = name;
            ShortDesc = shortDesc;
            LongDesc = longDesc;
        }

        public void Examine() {
            Console.WriteLine(Name);

            if(Game.Verbosity == Verbosity.Always || (Game.Verbosity == Verbosity.First && !Seen)) {
                Console.WriteLine(LongDesc);
            }
            else {
                Console.WriteLine(ShortDesc);
            }

            Seen = true;
        }
    }
}
