using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttack))]
public class Player : Unit
{
    protected override void Start()
    {
        base.Start();
        FindTarget<Enemy>();
    }
}