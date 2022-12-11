namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;

        public void Enter(string payload)
        {
            _sceneLoader.LoadAsync(payload, Loaded);
        }

        public void Exit()
        {
            
        }

        private void Loaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}