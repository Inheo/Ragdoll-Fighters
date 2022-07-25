using UnityEngine;

public class AnimatorTransition
{
    private const string IDLE_PARAMETER = "Idle";
    private const string RUN_FORWARD_PARAMETER = "run-forward";
    private const string RUN_BACK_PARAMETER = "run-back";

    private string _currentAnimation;

    private readonly Animator _animator;

    public AnimatorTransition(Animator animator)
    {
        _animator = animator;
        _currentAnimation = IDLE_PARAMETER;
    }

    public void Idle()
    {
        if (_currentAnimation == IDLE_PARAMETER)
            return;

        _currentAnimation = IDLE_PARAMETER;
        _animator.CrossFade(IDLE_PARAMETER, 0.1f);
    }

    public void RunForward()
    {
        if (_currentAnimation == RUN_FORWARD_PARAMETER)
            return;

        _currentAnimation = RUN_FORWARD_PARAMETER;
        _animator.CrossFade(RUN_FORWARD_PARAMETER, 0.1f);
    }

    public void RunBack()
    {
        if (_currentAnimation == RUN_BACK_PARAMETER)
            return;

        _currentAnimation = RUN_BACK_PARAMETER;
        _animator.CrossFade(RUN_BACK_PARAMETER, 0.1f);
    }
}
