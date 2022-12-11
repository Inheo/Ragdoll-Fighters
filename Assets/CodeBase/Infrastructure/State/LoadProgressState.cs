using CodeBase.Service.PersistentProgress;
using CodeBase.Service.SaveLoad;
using Scripts.Data;

namespace CodeBase.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;

        // TODO: Inject
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(GameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            LoadProgressOrInit();
        }

        public void Exit() { }

        private void LoadProgressOrInit()
        {
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();
        }

        private PlayerProgress NewProgress()
        {
            var progress = new PlayerProgress();
            return progress;
        }
    }
}