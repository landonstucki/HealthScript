public class Potion
{
    public string Name { get; private set; }
    public int Cost { get; private set; }
    private string type; // "healing" or "regen"

    public Potion(string name, int cost, string type)
    {
        Name = name;
        Cost = cost;
        this.type = type;
    }

    public void Use(Player player)
    {
        if (type == "healing")
        {
            player.Health.Heal(50);
            Console.WriteLine("You used a healing potion and restored 50 HP before the fight.\n");
        }
        else if (type == "regen")
        {
            player.HasRegenActive = true;
            Console.WriteLine("You drink a regeneration potion! You will heal 3 HP after each hit during this fight.\n");
        }
    }
}
