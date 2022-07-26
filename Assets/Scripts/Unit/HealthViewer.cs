using System.Collections;
using UnityEngine;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Transform _healthBar;

    private Coroutine _animationViewLostHealh;

    private void Start()
    {
        _unit.OnChangedHealth += HealthChanged;        

        _healthBar.localScale = new Vector3(1f, _healthBar.localScale.y, 1f);
    }

    private void OnDestroy()
    {
        _unit.OnChangedHealth -= HealthChanged;
    }

    private void HealthChanged(Unit.Health health)
    {
        StartCoroutine(ViewLostHealth(health, 0.5f));
    }

    private IEnumerator ViewLostHealth(Unit.Health health, float duration)
    {
        float lostTime = 0;
        Vector3 startScale = _healthBar.localScale;
        Vector3 endScale = startScale;
        endScale.x = health.CurrentHealth / health.MaxHealth;

        while(lostTime < 1)
        {
            lostTime += Time.deltaTime / duration;
            transform.localScale = Vector3.Lerp(startScale, endScale, lostTime);
            yield return null;
        }
    }
}