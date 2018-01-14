namespace AdventureGame {
    public class Keyword : GameObject {
        public delegate string[] CallHandler(params string[] args);
        public CallHandler Call;

        public Keyword(string name, string shortDesc, string longDesc, CallHandler callMethod) : base(name, shortDesc, longDesc) {
            Call = callMethod;
        }
    }
}
