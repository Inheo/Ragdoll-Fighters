using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public abstract class ButtonClickEmitter : MonoBehaviour
{
    public event System.Action OnClick;

    private void Awake()
    {
        Button button = GetComponent<Button>();

        button.onClick.AddListener(Click);
    }

    private void Click()
    {
        OnClick?.Invoke();
    }
}