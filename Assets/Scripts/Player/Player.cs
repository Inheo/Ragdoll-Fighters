using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttack))]
public class Player : Unit
{
    public override void Initialize()
    {
        base.Initialize();
        FindTarget<Enemy>();
    }
}