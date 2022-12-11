using UnityEngine;

public class AttackAnimationEventHandler : MonoBehaviour
{
    [SerializeField] private UnitAttack _attack;

    public void AttackPlayEnded()
    {
        _attack.AttackPlayEnded();
    }
}
