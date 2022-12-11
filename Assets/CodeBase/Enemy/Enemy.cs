using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class Enemy : Unit
{
    protected override void Start()
    {
        base.Start();
        FindTarget<Player>();
    }
}