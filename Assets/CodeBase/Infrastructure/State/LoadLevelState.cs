using System.Threading.Tasks;
using CodeBase.Infrastructure.Factory;
using CodeBase.Service.StaticData;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnitBase = CodeBase.Unit.Unit;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private readonly SceneLoader _sceneLoader;
        private readonly GameStateMachine _stateMachine;
        private readonly IGameFactory _factory;
        private readonly IStaticDataService _staticData;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory factory, IStaticDataService staticData)
        {
            _sceneLoader = sceneLoader;
            _stateMachine = stateMachine;
            _factory = factory;
            _staticData = staticData;
        }

        public void Enter(string payload)
        {
            _sceneLoader.LoadAsync(payload, Loaded);
        }

        public void Exit() { }

        private async void Loaded()
        {
            await InitGameWorld();
            _stateMachine.Enter<GameLoopState>();
        }

        private async Task InitGameWorld()
        {
            LevelStaticData levelData = LevelStaticData();

            UnitBase player = (await CreatePlayer(levelData)).GetComponentInChildren<UnitBase>();
            UnitBase enemy = (await CreateEnemy(levelData)).GetComponentInChildren<UnitBase>();
            
            InitUnit(player, enemy);
            InitUnit(enemy, player);
        }

        private LevelStaticData LevelStaticData() =>
            _staticData.ForLevel(SceneManager.GetActiveScene().name);

        private async Task<GameObject> CreatePlayer(LevelStaticData levelData) =>
            await _factory.CreatePlayer(levelData.PlayerPosition);

        private async Task<GameObject> CreateEnemy(LevelStaticData levelData) =>
            await _factory.CreateEnemy(levelData.EnemyData.EnemyTypeId, levelData.EnemyData.Position);

        private void InitUnit(UnitBase he, UnitBase hisEnemy) => he.SetTarget(hisEnemy);
    }
}