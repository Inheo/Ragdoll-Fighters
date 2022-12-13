public interface IHealth : ITakeDamage
{
    event System.Action OnHealthChanged;
    float Current { get; set; }
    float Max { get; set; }
}