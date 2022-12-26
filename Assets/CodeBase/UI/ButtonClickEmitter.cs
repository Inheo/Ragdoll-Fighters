using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class ButtonClickEmitter : MonoBehaviour
    {
        public event System.Action OnClick;

        private void Awake()
        {
            Button button = GetComponent<Button>();

            button.onClick.AddListener(Click);
        }

        protected virtual void Click()
        {
            OnClick?.Invoke();
        }
    }
}