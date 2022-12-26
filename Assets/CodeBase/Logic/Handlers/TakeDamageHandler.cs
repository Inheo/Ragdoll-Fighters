using CodeBase.Unit.Interfaces;
using CodeBase.Unit;
using UnityEngine;
using UnitBase = CodeBase.Unit.Unit;

namespace CodeBase.Logic.Handlers
{
    public class TakeDamageHandler : MonoBehaviour, ITakeDamage
    {
        private UnitHealth _unit;

        public UnitBase Owner { get; private set; }

        private void Start()
        {
            Owner = GetComponentInParent<UnitBase>();
            _unit = GetComponentInParent<UnitHealth>();
        }

        public void TakeDamage(float damage)
        {
            _unit.TakeDamage(damage);
        }
    }
}