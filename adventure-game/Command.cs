namespace adventure_game {
    public class Command {
        public delegate string[] CallHandler(params string[] args);

        public string Name { get; protected set; }
        public string Shortcut { get; protected set; }
        public CallHandler Call { get; set; }

        public Command(string name, string shortcut, CallHandler call = null) {
            Call = call;
        }
    }
}
