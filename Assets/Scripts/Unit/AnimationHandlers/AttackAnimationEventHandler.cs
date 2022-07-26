using UnityEngine;

public class AttackAnimationEventHandler : MonoBehaviour
{
    [SerializeField] private PlayerAttack _attack;

    public void AttackPlayEnded()
    {
        _attack.AttackPlayEnded();
    }
}
