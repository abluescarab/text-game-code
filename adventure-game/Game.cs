using System;
using System.Collections.Generic;
using System.Linq;

namespace adventure_game {
    static class Game {
        public static bool Started { get; private set; }
        public static Location Location { get; private set; }
        public static Verbosity Verbosity { get; private set; }
        public static string Player { get; private set; }
        public static List<Item> Inventory { get; private set; }
        public static Dictionary<string, Command> Commands { get; private set; }

        static Game() {
            Verbosity = Verbosity.First;
            Inventory = new List<Item>();
            Commands = new Dictionary<string, Command>();
            InitializeCommands();
        }

        public static void Start(string name) {
            Player = name;
            Started = true;
        }

        public static void Quit() {
            Console.Write("Save first? (y/n) ");
            if(Console.Read() == 'y') {
                Save();
            }

            Started = false;
        }

        public static void ParseInput(string input) {
            string[] inputs = input.Split(' ');

            foreach(string command in inputs) {
                Commands[command].Call(inputs.Skip(1).ToArray());
            }
        }

        public static void Move(Directions direction) {
            Location = Location.Directions[direction];
        }

        public static void Save() {

        }

        public static void Load() {

        }

        private static void InitializeCommands() {
            /* Command ref:
             *  north
             *  south
             *  east
             *  west
             *  up
             *  down
             *  examine
             *  save
             *  load
             *  verbose
             *  brief
             *  superbrief
             *  quit
             *  enter
             *  exit
             *  take
             *  throw
             *  open
             *  read
             *  drop
             *  put in
             *  turn with
             *  turn on
             *  turn off
             *  move
             *  attack with
             *  inventory
             *  eat
             *  close
             *  attach to
             *  kill self with
             *  break with
             *  drink
             *  smell
             *  listen
             */
        }
    }
}
