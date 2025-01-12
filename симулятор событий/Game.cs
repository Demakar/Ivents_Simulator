namespace ivents_simulator
{
    class Game
    {
        public void game(Player player, Inventory inventory, Items items, RoomsGenerator generator, Ivents ivents, Game game)
        {
            while (true)
            {
                Console.WriteLine("-----------------------");
                generator.TextWalls(ivents);
                Console.WriteLine("Здоровье: " + player.health);
                Console.WriteLine("-----------------------");
                Console.WriteLine("I-инвентарь");
                Console.WriteLine("Q-искать предметы");
                Console.WriteLine("K-самоубийство");
                Console.WriteLine("-----------------------");
                string Action = "";
                try
                {
                    Action = Console.ReadLine();
                }
                catch (Exception)
                {

                }
                Console.Clear();
                //Движение
                if (Action == "w" || Action == "a" || Action == "d")
                {
                    string Letters = "wad";

                    for (byte i = 0; i < Letters.Length; i++)
                    {
                        string Letter = Letters[i].ToString();

                        if (Action == Letter && generator.walls[i])
                        {
                            Console.WriteLine("тут стена!");
                            Console.ReadKey();
                            break;
                        }
                        else if (Action == Letter && generator.Doors[i])
                        {
                            Console.WriteLine("тут запертая дверь!");
                            Console.ReadKey();
                            break;
                        }
                        else if (Action == Letter && generator.walls[i] == false)
                        {
                            generator.Walls(generator, ivents, player);
                            generator.itemGeneration(items, generator);
                            ivents.Ivents_Generator(player, inventory, generator, items, ivents);
                            if (ivents.fakeRed == 1)
                            {
                                ivents.red = false;
                                ivents.fakeRed = 0;
                            }
                            else if (ivents.fakeRed == 2)
                            {
                                ivents.fakeRed--;
                            }
                            if (ivents.Defense)
                            {
                                items.defenderTime--;
                                items.Defebder_Check(game, ivents);
                            }
                            break;
                        }
                    }
                }
                //не движение
                else if (Action == "i")
                {
                    inventory.InventoryMenu(items, inventory, player, generator, ivents);
                }
                else if (Action == "q")
                {
                    generator.Q_Action(generator, inventory);
                }
                else if (Action == "k")
                {
                    Console.WriteLine("вы сделали самоубийство");
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.WriteLine("нет такого действия");
                    Console.ReadKey();
                }
                Console.Clear();
                if (player.health <= 0)
                {
                    Console.WriteLine("Ты умер");
                    Console.ReadKey();
                    break;
                }
            }
        }
    }
}
