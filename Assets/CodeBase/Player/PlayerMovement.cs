using UnityEngine;
using Zenject;

public class PlayerMovement : UnitMovement
{
    [Inject] private JoystickInput _input;

    private void Start()
    {
        _input.OnActive += Move;
        _input.OnStop += Stop;
    }

    private void OnDestroy()
    {
        _input.OnActive -= Move;
        _input.OnStop -= Stop;
    }
}