using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.States;
using CodeBase.Service.PersistentProgress;
using CodeBase.Service.SaveLoad;
using CodeBase.Service.StaticData;
using CodeBase.UI;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class Game
    {
        public GameStateMachine StateMachine { get; private set; }

        public Game(IStartCoroutine coroutineRunner,
                    IPersistentProgressService progressService,
                    ISaveLoadService saveLoadService,
                    IGameFactory factory,
                    IStaticDataService staticData,
                    LevelStartButton levelStartButton,
                    Panels panels)
        {
            SceneLoader sceneLoader = new SceneLoader(coroutineRunner);
            StateMachine = new GameStateMachine(sceneLoader, progressService, saveLoadService, factory, staticData, levelStartButton, panels);
        }
    }
}