namespace ivents_simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            Items items = new Items();
            Player player = new Player();
            Game game = new Game();
            RoomsGenerator generator = new RoomsGenerator();
            Ivents ivents = new Ivents();

            game.game(player, inventory, items, generator, ivents, game);
        }
    }
}