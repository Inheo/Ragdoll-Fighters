using CodeBase.Unit.Interfaces;

namespace CodeBase.Unit.Interface
{
    public interface IHealth : ITakeDamage
    {
        event System.Action OnHealthChanged;
        float Current { get; set; }
        float Max { get; set; }
    }
}