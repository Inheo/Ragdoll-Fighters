using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Unit
{
    public class HealthViewer : MonoBehaviour
    {
        [SerializeField] private UnitHealth _unitHealth;
        [SerializeField] private Image _middleGround;
        [SerializeField] private Image _frontGround;

        private Coroutine _animationViewLostHealh;

        private void Start()
        {
            _unitHealth.OnHealthChanged += HealthChanged;

            _middleGround.fillAmount = 1f;
            _frontGround.fillAmount = 1f;
        }

        private void OnDestroy()
        {
            _unitHealth.OnHealthChanged -= HealthChanged;
        }

        private void HealthChanged()
        {
            _frontGround.fillAmount = _unitHealth.Current / _unitHealth.Max;

            PlayChangeHealthAnimation();
        }

        private void PlayChangeHealthAnimation()
        {
            if (_animationViewLostHealh != null)
                StopCoroutine(_animationViewLostHealh);

            _animationViewLostHealh = StartCoroutine(ViewLostHealth(0.5f, 0.5f));
        }

        private IEnumerator ViewLostHealth(float duration, float delay)
        {
            float lostTime = 0;
            float startValue = _middleGround.fillAmount;
            float endValue = _unitHealth.Current / _unitHealth.Max;

            while (lostTime < 1)
            {
                lostTime += Time.deltaTime / duration;
                _middleGround.fillAmount = Mathf.Lerp(startValue, endValue, lostTime);
                yield return null;
            }
        }
    }
}