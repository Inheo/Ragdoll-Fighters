using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(EnemyAttack))]
public class Enemy : Unit
{
    private void Start()
    {
        FindTarget<Player>();
    }
}