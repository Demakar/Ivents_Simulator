namespace ivents_simulator
{
    class RoomsGenerator
    {
        Random random = new Random();
        public bool[] walls = new bool[3];
        public bool[] Doors = new bool[3];
        byte Item = 0;
        public void Walls(RoomsGenerator generator, Ivents ivents, Player player)
        {
            byte WallsQuantitiy = (byte)random.Next(0, 5);

            for (byte i = 0; i < 3; i++)
            {
                walls[i] = false;
                Doors[i] = false;
            }

            if (WallsQuantitiy == 0)
            {

            }
            else if (WallsQuantitiy == 1 || WallsQuantitiy == 2)
            {
                generator.Blocker();
            }
            else if (WallsQuantitiy == 3 || WallsQuantitiy == 4)
            {
                generator.Blocker();
                generator.Blocker();
            }
            if (ivents.HellWay)
            {
                ivents.Devil(generator, player);
            }
        }
        void Blocker()
        {
            byte WallBlock = (byte)random.Next(1, 10);
            //стены
            if (WallBlock == 1 || WallBlock == 2)
            {
                walls[0] = true;
            }
            if (WallBlock == 3 || WallBlock == 4)
            {
                walls[1] = true;
            }
            if (WallBlock == 5 || WallBlock == 6)
            {
                walls[2] = true;
            }
            //двери
            if (WallBlock == 7)
            {
                Doors[0] = true;
            }
            if (WallBlock == 8)
            {
                Doors[1] = true;
            }
            if (WallBlock == 9)
            {
                Doors[2] = true;
            }
        }

        public void TextWalls(Ivents ivents)
        {
            if (ivents.red)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            //W стена 0
            if (walls[0])
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("      W-Вперед");
                Console.ResetColor();
            }
            else if (Doors[0])
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("      W-Вперед");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("      W-Вперед");
            }
            if (ivents.red)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            //A стена 1
            Console.WriteLine("");
            if (walls[1])
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("A-Влево      ");
                Console.ResetColor();
            }
            else if (Doors[1])
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("A-Влево      ");
                Console.ResetColor();
            }
            else
            {
                Console.Write("A-Влево      ");
            }
            if (ivents.red)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            //D стена 2
            if (walls[2])
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("D-Вправо");
                Console.ResetColor();
            }
            else if (Doors[2])
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("D-Вправо");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("D-Вправо");
            }
            if (ivents.red)
            {
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine("----------------------");
        }
        public void itemGeneration(Items items, RoomsGenerator generator)
        {
            byte ItemRand = (byte)random.Next(1, 15);
            Item = 0;
            if (ItemRand == 1 || ItemRand == 2 || ItemRand == 3)
            {
                Item = 1;
            }
            else if (ItemRand == 4 || ItemRand == 5)
            {
                Item = 2;
            }
            else if (ItemRand == 6)
            {
                Item = 3;
            }
            else if (ItemRand == 7)
            {
                Item = 4;
            }
        }
        public void Q_Action(RoomsGenerator generator, Inventory inventory)
        {
            if (Item > 0)
            {
                Console.WriteLine("Нажмите 1 чтобы взять предмет");
                Console.WriteLine("Вы что-то нашли!");
            }
            else
            {
                Console.WriteLine("Ничего не найдено");
            }

            int Item_Cell = 0;
            try
            {
                string input = Console.ReadLine();
                Item_Cell = Int32.Parse(input);
            }
            catch (FormatException)
            {
            }
            if (Item_Cell == 1)
            {
                try
                {
                    for (byte i = 0; i < 5; i++)
                    {
                        if (inventory.inventory[i] == 0)
                        {
                            inventory.inventory[i] = Item;
                            generator.Item = 0;
                            break;
                        }
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Инвентарь полон!");
                    Console.ReadKey();
                }
            }
            if (Item_Cell == 2)
            {
                for (byte i = 0; i < inventory.inventory.Length; i++)
                {
                    if (inventory.inventory[i] == 0)
                    {
                        inventory.inventory[i] = Item;
                        break;
                    }
                    else if (i == inventory.inventory.Length)
                    {
                        Console.WriteLine("инвентарь полон");
                        break;
                    }
                }
            }
        }
    }
}
