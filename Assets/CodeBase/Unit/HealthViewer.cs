using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private Unit _owner;
    [SerializeField] private Image _middleGround;
    [SerializeField] private Image _frontGround;

    private Coroutine _animationViewLostHealh;

    [Inject]
    public void Construct(Unit owner)
    {
        _owner = owner;
    }

    private void Start()
    {
        _owner.OnChangedHealth += HealthChanged;

        _middleGround.fillAmount = 1f;
        _frontGround.fillAmount = 1f;
    }

    private void OnDestroy()
    {
        _owner.OnChangedHealth -= HealthChanged;
    }

    private void HealthChanged(HealthSettings health)
    {
        _frontGround.fillAmount = health.CurrentHealth / health.StartHealth;

        PlayChangeHealthAnimation(health);
    }

    private void PlayChangeHealthAnimation(HealthSettings health)
    {
        if (_animationViewLostHealh != null)
            StopCoroutine(_animationViewLostHealh);

        _animationViewLostHealh = StartCoroutine(ViewLostHealth(health, 0.5f, 0.5f));
    }

    private IEnumerator ViewLostHealth(HealthSettings health, float duration, float delay)
    {
        float lostTime = 0;
        float startValue = _middleGround.fillAmount;
        float endValue = health.CurrentHealth / health.StartHealth;

        while (lostTime < 1)
        {
            lostTime += Time.deltaTime / duration;
            _middleGround.fillAmount = Mathf.Lerp(startValue, endValue, lostTime);
            yield return null;
        }
    }
}