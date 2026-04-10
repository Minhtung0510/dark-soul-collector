namespace DarkSoulCollector.Combat
{
    /// <summary>
    /// Contract for any entity that can take damage.
    /// </summary>
    public interface IDamageable
    {
        void TakeDamage(float amount);
        void Die();
    }
}
