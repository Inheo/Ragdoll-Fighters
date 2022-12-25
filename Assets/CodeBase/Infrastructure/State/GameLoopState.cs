using CodeBase.Infrastructure.Factory;
using CodeBase.UI;

namespace CodeBase.Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly LevelStartButton _levelStartButton;
        private readonly IGameFactory _factory;
        private readonly Panels _panels;

        public event System.Action OnLevelFinish;
        public event System.Action OnLevelFail;

        public GameLoopState(GameStateMachine stateMachine, LevelStartButton levelStartButton, IGameFactory factory, Panels panels)
        {
            _stateMachine = stateMachine;
            _levelStartButton = levelStartButton;
            _factory = factory;
            _panels = panels;

            _levelStartButton.OnClick += StartLevel;
            _panels.WinButton.onClick.AddListener(LoadNewGame);
            _panels.FailButton.onClick.AddListener(LoadNewGame);
        }

        public void Enter()
        {
            GameStats.IsStartLevel = false;
            GameStats.IsLevelEnd = false;
        }

        public void Exit() { }

        private void Win()
        {
            LevelEnd();
            _panels.ShowWinPanel();
            OnLevelFinish?.Invoke();
        }

        private void Fail()
        {
            LevelEnd();
            _panels.ShowFailPanel();
            OnLevelFail?.Invoke();
        }

        private void LevelEnd() => GameStats.IsLevelEnd = true;

        private void LoadNewGame() => _stateMachine.Enter<LoadLevelState, string>("Level-1");

        public void StartLevel() => GameStats.IsStartLevel = true;
    }
}