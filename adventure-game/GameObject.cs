using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game {
    public class GameObject {
        public string Name { get; protected set; }
        public string ShortDesc { get; protected set; }
        public string LongDesc { get; protected set; }
        public bool Seen { get; protected set; }

        public GameObject(string name, string shortDesc, string longDesc) {
            Name = name;
            ShortDesc = shortDesc;
            LongDesc = longDesc;
        }

        public void Examine() {
            Console.WriteLine(Name);

            if(Game.Verbosity==Verbosity.Always || (!Seen && Game.Verbosity == Verbosity.First)) {
                Console.WriteLine(LongDesc);
            }
            else {
                Console.WriteLine(ShortDesc);
            }

            Seen = true;
        }
    }
}
