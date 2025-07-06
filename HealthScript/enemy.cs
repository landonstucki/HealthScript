public class Enemy
{
    public string Name { get; set; }
    public HealthScript Health { get; private set; }
    public int AttackPower { get; set; }
    public int CoinReward { get; set; }

    public Enemy(string name, int maxHealth, int attackPower, int coinReward)
    {
        Name = name;
        Health = new HealthScript(maxHealth);
        AttackPower = attackPower;
        CoinReward = coinReward;
    }

    public void Attack(Player player)
    {
        player.Health.TakeDamage(AttackPower);
    }
}
