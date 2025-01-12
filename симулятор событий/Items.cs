namespace ivents_simulator
{
    class Items
    {
        public void Heal_Potion_Use(Player player, Inventory inventory)
        {
            if (player.health >= 10)
            {
                Console.WriteLine("полное здоровье");
                Console.ReadKey();
            }
            else
            {
                player.health++;
                Console.WriteLine("+1 здоровья");
                Console.ReadKey();
                for (byte i = 0; i < 5; i++)
                {
                    if (inventory.inventory[i] == 1)
                    {
                        inventory.inventory[i] = 0;
                        break;
                    }
                }
            }
        }
        public void Key_Use(RoomsGenerator generator, Inventory inventory)
        {
            for (byte i = 0; i < 3; i++)
            {
                if (generator.Doors[i])
                {
                    generator.Doors[i] = false;
                    for (byte o = 0; 0 < 5; o++)
                    {
                        if (inventory.inventory[o] == 2)
                        {
                            inventory.inventory[o] = 0;
                            break;
                        }
                    }
                    break;
                }
            }
        }
        public void Holy_Cross_Use(Ivents ivents, Inventory inventory, Player player)
        {
            ivents.HellWay = false;
            ivents.red = false;
            ivents.CreatureApocalipsise = false;
            player.health += 5;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("БОЖЕСТВЕННАЯ СИЛА");
            Console.ReadKey();
            Console.ResetColor();
            for (byte i = 0; 0 < 5; i++)
            {
                if (inventory.inventory[i] == 3)
                {
                    inventory.inventory[i] = 0;
                    break;
                }
            }
        }

        public byte defenderTime = 0;
        public void Defender_use(Ivents ivents, Inventory inventory)
        {
            ivents.Defense = true;
            defenderTime = 3;
            for (byte i = 0; 0 < 5; i++)
            {
                if (inventory.inventory[i] == 4)
                {
                    inventory.inventory[i] = 0;
                    break;
                }
            }
        }
        public void Defebder_Check(Game game, Ivents ivents)
        {
            if (defenderTime == 0)
            {
                ivents.Defense = false;
                defenderTime = 0;
            }
        }
    }
}
