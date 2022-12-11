using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    public event System.Action<Vector2> OnActive;
    public event System.Action OnStop;

    private void OnDisable()
    {
        OnStop?.Invoke();
    }

    private void Update()
    {
        if(_joystick.Direction == Vector2.zero)
        {
            OnStop?.Invoke();
            return;
        }

        OnActive?.Invoke(_joystick.Direction);
    }
}