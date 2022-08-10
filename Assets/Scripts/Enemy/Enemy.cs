using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class Enemy : Unit
{
    public override void Initialize()
    {
        base.Initialize();
        FindTarget<Player>();
    }
}