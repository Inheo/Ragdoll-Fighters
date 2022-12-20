using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.States;
using CodeBase.Service.PersistentProgress;
using CodeBase.Service.SaveLoad;
using CodeBase.Service.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, IStartCoroutine
    {
        [Inject] private IPersistentProgressService progressService;
        [Inject] private ISaveLoadService saveLoadService;
        [Inject] private IGameFactory factory;
        [Inject] private IStaticDataService staticData;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, progressService, saveLoadService, factory, staticData);
            _game.StateMachine.Enter<LoadProgressState>();

            DontDestroyOnLoad(this);
        }
    }
}