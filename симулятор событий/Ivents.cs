namespace ivents_simulator
{
    internal class Ivents
    {
        Random random = new Random();
        public bool red { get; set; }
        public bool HellWay { get; set; }
        public bool CreatureApocalipsise { get; set; }
        public byte fakeRed { get; set; }
        public bool Defense { get; set; }
        public void Ivents_Generator(Player player, Inventory inventory, RoomsGenerator generator, Items items, Ivents ivents)
        {
            byte RandomNumber = (byte)random.Next(0, 25);

            if (CreatureApocalipsise)
            {
                Creatue(player, inventory, items, generator, ivents);
            }
            else if (Defense == false && RandomNumber == 0 || RandomNumber == 1 || RandomNumber == 3)
            {
                Punch(player);
            }
            else if (Defense == false && RandomNumber == 4 || RandomNumber == 5)
            {
                stolen(inventory);
            }
            else if (Defense == false && RandomNumber == 6)
            {
                LockedRoom(generator);
            }
            else if (Defense == false && RandomNumber == 7 || RandomNumber == 8)
            {
                Creatue(player, inventory, items, generator, ivents);
            }
            else if (Defense == false && RandomNumber == 9)
            {
                HellWay = true;
            }
            else if (Defense == false && RandomNumber == 10)
            {
                Demon();
            }
            else if (red == false && RandomNumber == 11 || RandomNumber == 12)
            {
                Red();
            }
        }
        void Punch(Player player)
        {
            Console.WriteLine("вас кто-то ударил");
            player.health--;
            Console.ReadKey();
        }
        void stolen(Inventory inventory)
        {
            Console.WriteLine("у вас украли пердмет");
            Console.ReadKey();
            for (byte i = 0; i < inventory.inventory.Length; i++)
            {
                if (inventory.inventory[i] != 0)
                {
                    inventory.inventory[i] = 0;
                    break;
                }
            }
        }
        void LockedRoom(RoomsGenerator generator)
        {
            generator.walls[0] = false;

            generator.walls[1] = true;
            generator.walls[2] = true;
            generator.Doors[0] = true;
        }
        void Creatue(Player player, Inventory inventory, Items items, RoomsGenerator generator, Ivents ivents)
        {
            byte CreatueHP = (byte)random.Next(2, 4);
            Console.WriteLine("На вас напало существо!");
            Console.ReadKey();
            Console.Clear();
            while (true)
            {
                Console.WriteLine(player.health + " Здоровья");
                Console.WriteLine("");
                Console.WriteLine("1-Атака");
                Console.WriteLine("2-Защита");
                Console.WriteLine("3-Инвентарь");

                bool Defend = false;
                byte CreatueAction = (byte)random.Next(1, 3);
                int action = 0;
                try
                {
                    string input = Console.ReadLine();
                    action = Int32.Parse(input);
                }
                catch (FormatException)
                {
                }
                if (action == 1)
                {
                    Console.WriteLine("Вы атаковали!");
                    CreatueHP--;
                }
                else if (action == 2)
                {
                    Defend = true;
                    Console.WriteLine("вы защитились");
                }
                else if (action == 3)
                {
                    inventory.InventoryMenu(items, inventory, player, generator, ivents);
                }
                if (CreatueAction == 1 && Defend == false)
                {
                    Console.WriteLine("Существо атакует!");
                    player.health--;
                }
                if (CreatueAction == 2)
                {
                    Console.WriteLine("Существо Промахнулось!");
                }
                Console.ReadKey();
                Console.Clear();
                if (CreatueHP <= 0)
                {
                    Console.WriteLine("Существо убито");
                    Console.ReadKey();
                    break;
                }
                else if (player.health <= 0)
                {
                    break;
                }
            }
        }
        public void Devil(RoomsGenerator generator, Player player)
        {
            red = true;

            generator.walls[0] = false;

            generator.Doors[0] = false;
            generator.Doors[1] = false;
            generator.Doors[2] = false;

            generator.walls[1] = true;
            generator.walls[2] = true;

            player.health--;
        }
        public void Demon()
        {
            red = true;
            CreatureApocalipsise = true;
        }
        public void Red()
        {
            fakeRed = 2;
            red = true;
        }
    }
}
