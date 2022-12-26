using UnityEngine;
using UnitMono = CodeBase.Unit.Unit;

namespace CodeBase.Unit.Enemy
{
    [RequireComponent(typeof(EnemyMovement))]
    [RequireComponent(typeof(EnemyAttack))]
    public class Enemy : UnitMono { }
}