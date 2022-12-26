using UnityEngine;

namespace CodeBase.Unit.Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerAttack))]
    public class Player : Unit
    {
        private void Start() { }
    }
}