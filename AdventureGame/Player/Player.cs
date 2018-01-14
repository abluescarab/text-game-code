namespace AdventureGame {
    public class Player {
        public Inventory Inventory { get; set; }
        public string Name { get; set; }

        public Player(string name) {
            Name = name;
            Inventory = new Inventory();
        }

        public void PickUp(Item item) {
            Inventory.Items.Add(item);
            Game.Location.Items.Remove(item);
        }

        public void Drop(Item item) {
            Inventory.Items.Remove(item);
            Game.Location.Items.Add(item);
        }
    }
}
