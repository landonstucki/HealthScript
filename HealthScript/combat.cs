using System;
using System.Threading;

public class Combat
{
    private Player player;
    private Enemy enemy;
    private Random rand = new Random();

    public Combat(Player player, Enemy enemy)
    {
        this.player = player;
        this.enemy = enemy;
    }

    public bool StartBattle()
    {
        Console.WriteLine($"You start to fight the {enemy.Name}!");
        Thread.Sleep(1000);

        if (player.PotionInventory["Healing Potion"] > 0)
        {
            Console.WriteLine("Would you like to use a healing potion before the fight? (y/n):");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                Potion healPotion = new Potion("Healing Potion", 30, "healing");
                player.UsePotion(healPotion);
                Thread.Sleep(700);
            }
        }

        if (player.PotionInventory["Regeneration Potion"] > 0)
        {
            Console.WriteLine("Would you like to use a regeneration potion before the fight? (y/n):");
            string input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                Potion regenPotion = new Potion("Regeneration Potion", 20, "regen");
                player.UsePotion(regenPotion);
                Thread.Sleep(700);
            }
        }

        while (!player.Health.IsDead() && !enemy.Health.IsDead())
        {
            int playerDamage = rand.Next(0, player.AttackPower + 1);
            enemy.Health.TakeDamage(playerDamage);
            Console.WriteLine($"You hit the {enemy.Name} for {playerDamage} damage.");
            Console.WriteLine($"{enemy.Name} Health: {enemy.Health.CurrentHealth} | Player Health: {player.Health.CurrentHealth}");
            Thread.Sleep(2500);

            if (enemy.Health.IsDead())
            {
                Console.WriteLine($"The {enemy.Name} has been defeated! You win!");
                player.Coins += enemy.CoinReward;
                Console.WriteLine($"You received {enemy.CoinReward} coins. Total coins: {player.Coins}\n");
                player.HasRegenActive = false;
                Thread.Sleep(1500);
                return true;
            }

            int enemyDamage = rand.Next(0, enemy.AttackPower + 1);
            player.Health.TakeDamage(enemyDamage);
            Console.WriteLine($"The {enemy.Name} hits you for {enemyDamage} damage.");

            if (player.HasRegenActive && player.Health.CurrentHealth > 0)
            {
                player.Health.Heal(3);
                Console.WriteLine("Your regeneration potion heals you for 3 HP!");
            }

            Console.WriteLine($"{enemy.Name} Health: {enemy.Health.CurrentHealth} | Player Health: {player.Health.CurrentHealth}");
            Thread.Sleep(2500);

            if (player.Health.IsDead())
            {
                Console.WriteLine("You have been defeated! You are exhausted and must recover...\n");
                double lostCoins = player.Coins * .05;
                player.Coins -= lostCoins;
                Console.WriteLine($"You have lost {lostCoins} coins!");
                player.HasRegenActive = false;
                Thread.Sleep(1500);
                return false;
            }

            Console.WriteLine();
        }

        return true;
    }
}
