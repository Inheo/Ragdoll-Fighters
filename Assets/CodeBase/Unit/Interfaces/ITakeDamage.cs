using CodeBase.Unit;

namespace CodeBase.Unit.Interfaces
{
    public interface ITakeDamage
    {
        Unit Owner { get; }
        void TakeDamage(float damage);
    }
}