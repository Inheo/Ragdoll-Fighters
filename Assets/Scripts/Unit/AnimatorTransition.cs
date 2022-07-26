using UnityEngine;

public class AnimatorTransition
{
    private const string IDLE_PARAMETER = "Idle";
    private const string RUN_FORWARD_PARAMETER = "run-forward";
    private const string RUN_BACK_PARAMETER = "run-back";
    private const string RIGHT_HOOK_PARAMETER = "right-hook";
    private const string LEFT_HOOK_PARAMETER = "left-hook";
    private const string RIGHT_KICK_PARAMETER = "right-kick";
    private const string LEFT_KICK_PARAMETER = "left-kick";

    private string _currentAnimation;

    private readonly Animator _animator;

    public AnimatorTransition(Animator animator)
    {
        _animator = animator;
        _currentAnimation = IDLE_PARAMETER;
    }

    public void Idle()
    {
        TryFadeState(IDLE_PARAMETER, 0.1f);
    }

    public void RunForward()
    {
        TryFadeState(RUN_FORWARD_PARAMETER, 0.1f);
    }

    public void RunBack()
    {
        TryFadeState(RUN_BACK_PARAMETER, 0.1f);
    }

    public void PlayRandomAttackState()
    {
        var randomIndex = Random.Range(0, 4);

        if (randomIndex == 0)
            PlayRightHook();
        else if (randomIndex == 1)
            PlayLeftHook();
        else if (randomIndex == 2)
            PlayRightKick();
        else if (randomIndex == 3)
            PlayLeftKick();
        else
            Debug.Log("WTF???!!!");
    }

    public void PlayRightHook()
    {
        AttackLayerEnable();

        TryFadeState(RIGHT_HOOK_PARAMETER, 0.05f, 1);
    }

    public void PlayLeftHook()
    {
        AttackLayerEnable();

        TryFadeState(LEFT_HOOK_PARAMETER, 0.05f, 1);
    }

    public void PlayRightKick()
    {
        AttackLayerEnable();

        TryFadeState(RIGHT_KICK_PARAMETER, 0.05f, 1);
    }

    public void PlayLeftKick()
    {
        AttackLayerEnable();

        TryFadeState(LEFT_KICK_PARAMETER, 0.05f, 1);
    }

    public void AttackLayerDisable()
    {
        _animator.SetLayerWeight(1, 0);
    }

    public void AttackLayerEnable()
    {
        _animator.SetLayerWeight(1, 1);
    }

    private void TryFadeState(string stateName, float normalizedTransitionDuration, int layer = 0)
    {
        if (_currentAnimation == stateName)
            return;

        _currentAnimation = stateName;
        _animator.CrossFade(stateName, normalizedTransitionDuration, layer);
    }
}