using UnityEngine;

public class UnitRotator : MonoBehaviour
{
    [SerializeField] private Unit _target;

    private void Update()
    {
        Vector3 direction = _target.transform.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}