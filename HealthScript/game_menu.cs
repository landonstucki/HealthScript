using System;

public class GameMenu
{
    public Enemy ChooseEnemyOrBuyPotions(Player player)
    {
        while (true)
        {
            Console.WriteLine("====================================");
            Console.WriteLine($"Coins: {player.Coins} | Healing Potions: {player.PotionInventory["Healing Potion"]} | Regen Potions: {player.PotionInventory["Regeneration Potion"]}");
            Console.WriteLine($"Player Health: {player.Health.CurrentHealth}");
            Console.WriteLine("====================================\n");

            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Fight Wisp (Lvl 5) - Reward: 10 coins");
            Console.WriteLine("2. Fight Harpy (Lvl 10) - Reward: 15 coins");
            Console.WriteLine("3. Fight Banshee (Lvl 20) - Reward: 25 coins");
            Console.WriteLine("4. Fight Baby Dragon (Lvl 40) - Reward: 40 coins");
            Console.WriteLine("5. Fight Dragon (Lvl 90) - Reward: 100 coins");
            Console.WriteLine("6. Buy regeneration potion (Cost: 20 coins)");
            Console.WriteLine("7. Buy healing potion (Cost: 30 coins)");
            Console.Write("Enter a number (1-7): ");
            string input = Console.ReadLine();

            try
            {
                int choice = int.Parse(input);

                if (choice == 1)
                    return new Enemy("Wisp", 30, 5, 10);
                else if (choice == 2)
                    return new Enemy("Harpy", 50, 8, 15);
                else if (choice == 3)
                    return new Enemy("Banshee", 80, 12, 25);
                else if (choice == 4)
                    return new Enemy("Baby Dragon", 120, 18, 40);
                else if (choice == 5)
                    return new Enemy("Dragon", 300, 25, 100);
                else if (choice == 6)
                {
                    if (player.Coins >= 20)
                    {
                        player.Coins -= 20;
                        player.PotionInventory["Regeneration Potion"]++;
                        Console.WriteLine($"You bought a regeneration potion! You now have {player.PotionInventory["Regeneration Potion"]}.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough coins to buy a regeneration potion!\n");
                    }
                }
                else if (choice == 7)
                {
                    if (player.Coins >= 30)
                    {
                        player.Coins -= 30;
                        player.PotionInventory["Healing Potion"]++;
                        Console.WriteLine($"You bought a healing potion! You now have {player.PotionInventory["Healing Potion"]}.\n");
                    }
                    else
                    {
                        Console.WriteLine("Not enough coins to buy a healing potion!\n");
                    }
                }
                else
                {
                    Console.WriteLine("Please choose a valid number between 1 and 7.\n");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a number.\n");
            }
        }
    }
}
