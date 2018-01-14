namespace adventure_game {
    /// <summary>
    /// Controls the verbosity of item and location descriptions.
    /// </summary>
    public enum Verbosity {
        Always, // always display verbose description
        First,  // only display verbose description on first visit/pickup
        Never   // never display verbose description
    }
}
