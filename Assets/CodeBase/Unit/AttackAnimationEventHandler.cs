using UnityEngine;

namespace CodeBase.Unit
{
    public class AttackAnimationEventHandler : MonoBehaviour
    {
        [SerializeField] private UnitAttack _attack;

        public void AttackPlayEnded()
        {
            _attack.AttackPlayEnded();
        }
    }
}