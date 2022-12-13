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
        [Inject] private IAssetProvider _assets;
        [Inject] private IStaticDataService _staticDataService;
        [Inject] private DiContainer _diContainer;

        public GameObject Player { get; private set; }

        public GameObject Enemy { get; private set; }

        public async Task<GameObject> CreatePlayer(Vector3 at) 
        {
            GameObject player = await Instantiate(AssetAddress.PLAYER_PATH, at);
            Player = player;
            return player;
        }

        public async Task<GameObject> CreateEnemy(EnemyTypeId enemyTypeId, Vector3 at)
        {
            EnemyStaticData enemyData = _staticDataService.ForEnemy(enemyTypeId);
            GameObject prefab = await _assets.Load<GameObject>(enemyData.PrefabReference);
            GameObject enemy = Object.Instantiate(prefab, at, Quaternion.identity);

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