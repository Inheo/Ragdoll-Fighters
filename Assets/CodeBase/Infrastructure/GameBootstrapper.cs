using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.States;
using CodeBase.Service.PersistentProgress;
using CodeBase.Service.SaveLoad;
using CodeBase.Service.StaticData;
using CodeBase.UI;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, IStartCoroutine
    {
        [Inject] private IPersistentProgressService _progressService;
        [Inject] private ISaveLoadService _saveLoadService;
        [Inject] private IGameFactory _factory;
        [Inject] private IStaticDataService _staticData;
        [Inject] private LevelStartButton _levelStartButton;
        [Inject] private Panels _panels;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, _progressService, _saveLoadService, _factory, _staticData, _levelStartButton, _panels);
            _game.StateMachine.Enter<LoadProgressState>();

            DontDestroyOnLoad(this);
        }
    }
}