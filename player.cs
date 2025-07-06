using System;
using System.Collections.Generic;

public class Player
{
    public HealthScript Health { get; private set; }
    public int AttackPower { get; set; }
    public double Coins { get; set; }
    public bool HasRegenActive { get; set; }

    public Dictionary<string, int> PotionInventory { get; private set; }

    public Player(int maxHealth, int attackPower = 10)
    {
        Health = new HealthScript(maxHealth);
        AttackPower = attackPower;
        Coins = 0;
        HasRegenActive = false;
        PotionInventory = new Dictionary<string, int>
        {
            { "Healing Potion", 0 },
            { "Regeneration Potion", 0 }
        };
    }

    public void UsePotion(Potion potion)
    {
        if (PotionInventory.ContainsKey(potion.Name) && PotionInventory[potion.Name] > 0)
        {
            potion.Use(this);
            PotionInventory[potion.Name]--;
            Console.WriteLine($"{potion.Name} left: {PotionInventory[potion.Name]}\n");
        }
        else
        {
            Console.WriteLine($"You don’t have any {potion.Name} left.\n");
        }
    }
}
