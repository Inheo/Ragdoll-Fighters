using UnityEngine;

public class EnemyMovement : UnitMovement
{
    [SerializeField] private float _stopDistance = 1f;
    [SerializeField] private Player _player;

    private void Update()
    {
        if(Vector3.Distance(transform.position, _player.transform.position) > _stopDistance)
        {
            Vector2 direction = (_player.transform.position - transform.position).normalized;
            Move(direction);
        } 
        else
        {
            Stop();
        }       
    }
}