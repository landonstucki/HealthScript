public class HealthScript
{
    private int maxHealth;
    private int currentHealth;

    public HealthScript(int maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
    }

    public int CurrentHealth => currentHealth;

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth < 0)
            currentHealth = 0;
    }

    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }

    public bool IsDead() => currentHealth == 0;

    public void Reset() => currentHealth = maxHealth;
}
