public interface ITakeDamage
{
    public Unit Owner { get; }
    
    
    public void TakeDamage(float damage);
}