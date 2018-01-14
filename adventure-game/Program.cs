using System;

namespace adventure_game {
    class Program {
        static void Main(string[] args) {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();
            Game.Start(name);

            while(Game.Started) {
                Game.ParseInput(Console.ReadLine());
            }
        }
    }
}
