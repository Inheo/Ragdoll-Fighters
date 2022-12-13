public interface IAttack
{
    float AttackCooldown { get; set; }
    float Damage { get; set; }

    void EnableAttack();
    void DisableAttack();
}