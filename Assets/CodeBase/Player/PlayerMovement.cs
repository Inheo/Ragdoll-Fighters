using UnityEngine;
using Zenject;

public class PlayerMovement : UnitMovement
{
    [SerializeField] private JoystickInput _input;

    [Inject]
    public void Construct(JoystickInput input)
    {
        _input = input;
    }

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