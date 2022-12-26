using DG.Tweening;
using UnityEngine;

namespace CodeBase.Logic.Animation
{
    public class ScaleAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.3f;
        [SerializeField] private float _delay = 0.3f;
        [SerializeField] private Vector3 _startScaleMultiply;
        private void Start()
        {
            Vector3 newScale = new Vector3(_startScaleMultiply.x * transform.lossyScale.x, _startScaleMultiply.y * transform.lossyScale.y, _startScaleMultiply.z * transform.lossyScale.z);

            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOScale(newScale, _duration).SetDelay(_delay));
            sequence.SetLoops(-1, LoopType.Yoyo);
        }
    }
}