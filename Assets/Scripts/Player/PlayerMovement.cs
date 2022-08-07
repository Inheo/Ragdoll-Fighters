using UnityEngine;

public class PlayerMovement : UnitMovement
{
    [SerializeField] private JoystickInput _input;

    private void Start()
    {
        _input.OnActive += Move;
        _input.OnStop += Stop;
    }
}