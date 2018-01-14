using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AdventureGame {
    public static class Game {
        public static Player Player { get; private set; }
        public static Location Location { get; private set; }
        public static List<Location> Locations { get; private set; }
        public static Dictionary<string, Keyword> Keywords { get; private set; }
        public static Verbosity Verbosity { get; set; }
        public static bool Started { get; private set; }
        public static string[] Input { get; private set; }

        static Game() {
            Locations = new List<Location>();
            Keywords = new Dictionary<string, Keyword>();
            Verbosity = Verbosity.First;

            Initialize();
        }

        public static void Start(string player) {
            Player = new Player(player);
            if(Locations.Count > 0) {
                Location = Locations[0];
            }
            Started = true;
        }

        public static void TryQuit() {
            Started = false;
        }

        public static void Quit() {

        }

        public static void ParseInput(string input) {
            string[] inputs = input.Split(' ');

            foreach(string keyword in inputs) {
                if(Keywords.ContainsKey(keyword)) {
                    Keywords[keyword].Call(inputs.Skip(1).ToArray());
                }
            }
        }

        public static void Move(Directions direction) {
            Location = Location.Directions[direction];
        }

        public static void Save() {

        }

        public static void Load() {

        }

        private static void Initialize() {
            InitializeKeywords();
            InitializeLocations();
        }

        private static void InitializeKeywords() {
            Keywords.Add("examine", new Keyword("examine", "", "", delegate (string[] args) {
                if(args.Length > 0) {


                    return new string[] { args[0] };
                }
                else {
                    return new string[0];
                }
            }));

            Console.WriteLine(Keywords.Values.ElementAt(0).Call().Length);
            Console.WriteLine(Keywords.Values.ElementAt(0).Call("Arg").Length);
        }

        private static void InitializeLocations() {
            //Location location = new Location("Your House", "Home, sweet home.", "You're in your house. There's an " +
            //    "L-shaped oak desk in the southeast corner, with a door along the west wall. A simple bed is " +
            //    "situated in the northeast corner, a short table with a single drawer to the left of the pillows. " +
            //    "The rest of the room is bare.");
            string itemLoc = AppDomain.CurrentDomain.BaseDirectory + "JSON\\Items.json";
            dynamic results = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(itemLoc));

            foreach(JObject item in results) {
                //item.Remove("Use");
                //Item i = JsonConvert.DeserializeObject<Item>(item.ToString());

                string code = item.Property("Use").Value.ToString();
                CompileCode(code);
                //List<Item> items = LoadItems(code);
                //List<ite>
            }

            //    string json = @"{
            // 2  'Email': 'james@example.com',
            // 3  'Active': true,
            // 4  'CreatedDate': '2013-01-20T00:00:00Z',
            // 5  'Roles': [
            // 6    'User',
            // 7    'Admin'
            // 8  ]
            // 9}";
            // Account account = JsonConvert.DeserializeObject<Account>(json);
            // Console.WriteLine(account.Email);
        }

        //private static Item.UseHandler CompileCode(string code) {
        private static void CompileCode(string code) { 
            CodeDomProvider codeProvider = new CSharpCodeProvider();

            // compiler params
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = true;
            //compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            //compilerParams.ReferencedAssemblies.Add("System.dll");
            //compilerParams.ReferencedAssemblies.

            CompilerResults results = codeProvider.CompileAssemblyFromSource(compilerParams, code);

            //CompilerResults results = codeProvider.CompileAssemblyFromSource(compilerParams, code);
            
            //List<Item> items = new List<Item>();

            //foreach(var itemType in results.CompiledAssembly.DefinedTypes) {
            //    ConstructorInfo ctor = itemType.GetConstructor(Type.EmptyTypes);
            //    object instance = ctor.Invoke(null);
            //    items.Add(instance as Item);
            //}

            //return items;
        }

        //public static List<Item> LoadItems(string code) {
        //    CodeDomProvider codeProvider = new CSharpCodeProvider();

        //    // compiler params
        //    CompilerParameters compilerParams = new CompilerParameters();
        //    compilerParams.CompilerOptions = "/target:library /optimize";
        //    compilerParams.GenerateExecutable = false;
        //    compilerParams.GenerateInMemory = true;
        //    compilerParams.IncludeDebugInformation = false;
        //    compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
        //    compilerParams.ReferencedAssemblies.Add("System.dll");
        //    //compilerParams.ReferencedAssemblies.

        //    CompilerResults results = codeProvider.CompileAssemblyFromSource(compilerParams, code);
        //    List<Item> items = new List<Item>();

        //    foreach(var itemType in results.CompiledAssembly.DefinedTypes) {
        //        ConstructorInfo ctor = itemType.GetConstructor(Type.EmptyTypes);
        //        object instance = ctor.Invoke(null);
        //        items.Add(instance as Item);
        //    }

        //    return items;
        //}
    }
}
