using UnityEngine;

namespace CodeBase.Unit.Settings
{
    [System.Serializable]
    public class AttackSettings
    {
        [SerializeField] private float _reload = 1f;
        [SerializeField] private float _distance = 2f;

        public float Reload => _reload;
        public float Distance => _distance;

        public AttackSettings(float reload, float distance)
        {
            _reload = reload;
            _distance = distance;
        }
    }
}