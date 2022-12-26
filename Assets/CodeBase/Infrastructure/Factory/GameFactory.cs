using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Service.StaticData;
using CodeBase.StaticData;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IStaticDataService _staticDataService;
        private readonly DiContainer _diContainer;

        public GameObject Player { get; private set; }

        public GameObject Enemy { get; private set; }

        public GameFactory(IAssetProvider assets, IStaticDataService staticDataService, DiContainer diContainer)
        {
            _assets = assets;
            _staticDataService = staticDataService;
            _diContainer = diContainer;
        }
        
        public void CleanUp()
        {
            _assets.CleanUp();
            Object.Destroy(Player);
            Object.Destroy(Enemy);
        }

        public async Task<GameObject> CreatePlayer(Vector3 at)
        {
            Player = await Instantiate(AssetAddress.PLAYER_PATH, at);
            return Player;
        }

        public async Task<GameObject> CreateEnemy(EnemyTypeId enemyTypeId, Vector3 at)
        {
            EnemyStaticData enemyData = _staticDataService.ForEnemy(enemyTypeId);
            GameObject prefab = await _assets.Load<GameObject>(enemyData.PrefabReference);
            GameObject enemy = _diContainer.InstantiatePrefab(prefab, at, Quaternion.identity, null);

            IHealth health = enemy.GetComponentInChildren<IHealth>();
            health.Max = enemyData.HealthPoint;
            health.Current = enemyData.HealthPoint;

            IAttack attack = enemy.GetComponentInChildren<IAttack>();
            attack.Damage = enemyData.AttackDamage;
            attack.AttackCooldown = enemyData.AttackCooldown;

            CheckAttackRange attackRange = enemy.GetComponentInChildren<CheckAttackRange>();
            attackRange.Distance = enemyData.AttackDistance;
            attackRange.Attack = attack;

            enemy.GetComponentInChildren<UnitMovement>().Speed = enemyData.MoveSpeed;

            Enemy = enemy;
            return enemy;
        }

        private async Task<GameObject> Instantiate(string path, Vector3 at, Transform parent = null)
        {
            GameObject prefab = await _assets.Load<GameObject>(path);
            return _diContainer.InstantiatePrefab(prefab, at, Quaternion.identity, parent);
        }
    }
}