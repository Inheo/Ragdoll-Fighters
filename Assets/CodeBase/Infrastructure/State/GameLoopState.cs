using CodeBase.UI;
using CodeBase.Infrastructure.Factory;
using CodeBase.Unit;

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
            CleanUp();

            _factory.Player.GetComponentInChildren<UnitDeath>().OnDeath += Fail;
            _factory.Enemy.GetComponentInChildren<UnitDeath>().OnDeath += Win;
        }

        public void Exit()
        {
            _factory.CleanUp();
            _factory.Player.GetComponentInChildren<UnitDeath>().OnDeath -= Fail;
            _factory.Enemy.GetComponentInChildren<UnitDeath>().OnDeath -= Win;
        }

        private void CleanUp()
        {
            GameStats.IsStartLevel = false;
            GameStats.IsLevelEnd = false;
            _panels.FastHideAll();
            _levelStartButton.transform.parent.gameObject.SetActive(true);
        }

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