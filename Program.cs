// Landon Stucki
// 6/28/2025
using System;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player(100, 20);
        GameMenu menu = new GameMenu();

        while (true)
        {
            Enemy selectedEnemy = menu.ChooseEnemyOrBuyPotions(player);

            Combat combat = new Combat(player, selectedEnemy);
            bool playerWon = combat.StartBattle();

            if (!playerWon)
            {
                Console.WriteLine("You are exhausted and need to recover before your next fight.");
                player.Health.Reset();
                Console.WriteLine("You slowly recover your health...\n");
            }
            else
            {
                Console.WriteLine("You survived! Choose a new monster or buy potions.\n");
            }
        }
    }
}