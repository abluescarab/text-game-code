namespace adventure_game {
    public class Item : GameObject {
        public delegate string[] UseHandler(params string[] args);

        public UseHandler Use { get; set; }

        public Item(string name, string shortDesc, string longDesc,
            UseHandler useMethod = null) : base(name, shortDesc, longDesc) {
            Use = useMethod;
        }
    }
}
