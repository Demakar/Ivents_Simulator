namespace ivents_simulator
{
    class Inventory
    {
        //массив инвенторя
        public int[] inventory = new int[5];

        public Dictionary<int, string> itemNames = new Dictionary<int, string>
        {
            { 0, "Пусто" },
            { 1, "Зелье лечения" },
            { 2, "Ключ" },
            { 3, "Священный крест" },
            { 4, "Защитник" }
        };

        //методы
        public void InventoryDisplay(Items items)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.Write($"{i}: ");

                if (itemNames.ContainsKey(inventory[i])) // проверяем есть ли в словаре элемент из инвентаря
                {
                    Console.WriteLine(itemNames[inventory[i]]);
                }
                else
                {
                    Console.WriteLine("Пусто");
                }
            }
        }
        public void InventoryMenu(Items items, Inventory inventory, Player player, RoomsGenerator generator, Ivents ivents)
        {
            while (true)
            {
                Console.WriteLine("1-убрать предмет");
                Console.WriteLine("2-использовать предмет");
                Console.WriteLine("----------------------");

                inventory.InventoryDisplay(items);

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
                    Console.WriteLine("выберите ячейку которую надо отчистить");
                    byte inventory_Cell = 6;
                    try
                    {
                        string input = Console.ReadLine();
                        inventory_Cell = byte.Parse(input);

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("неверный формат");
                    }

                    if (inventory_Cell > inventory.inventory.Length)
                    {
                        Console.WriteLine("такой ячейки инвентаря нет");
                    }
                    else if (inventory.inventory[inventory_Cell] == 0)
                    {
                        Console.WriteLine("ячейка и так пуста");
                    }
                    else
                    {
                        inventory.inventory[inventory_Cell] = 0;
                    }
                }
                else if (action == 2)
                {
                    Console.WriteLine("выберите предмет который хотите использовать");
                    byte inventory_Cell = 6;
                    try
                    {
                        string input = Console.ReadLine();
                        inventory_Cell = byte.Parse(input);

                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("неверный формат");
                    }
                    if (inventory_Cell > inventory.inventory.Length)
                    {
                        Console.WriteLine("такой ячейки инвентаря нет");
                    }
                    else if (inventory.inventory[inventory_Cell] == 0)
                    {
                        Console.WriteLine("ячейка и так пуста");
                    }
                    else
                    {
                        if (inventory.inventory[inventory_Cell] == 1)
                        {
                            items.Heal_Potion_Use(player, inventory);
                        }
                        if (inventory.inventory[inventory_Cell] == 2)
                        {
                            items.Key_Use(generator, inventory);
                        }
                        if (inventory.inventory[inventory_Cell] == 3)
                        {
                            items.Holy_Cross_Use(ivents, inventory, player);
                        }
                        if (inventory.inventory[inventory_Cell] == 4)
                        {
                            items.Defender_use(ivents, inventory);
                        }
                    }
                }
                else
                {
                    break;
                }
                Console.Clear();
            }
        }
    }
}

