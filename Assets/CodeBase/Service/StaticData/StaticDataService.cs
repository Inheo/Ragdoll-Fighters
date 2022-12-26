using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Service.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string ENEMY_DATA_PATH = "StaticData/Enemy";
        private const string LEVEL_STATIC_DATA = "StaticData/Level";

        private Dictionary<EnemyTypeId, EnemyStaticData> _enemies;
        private Dictionary<string, LevelStaticData> _levels;

        public StaticDataService()
        {
            _enemies = Resources
                .LoadAll<EnemyStaticData>(ENEMY_DATA_PATH)
                .ToDictionary(x => x.EnemyTypeId, x => x);

            _levels = Resources
                .LoadAll<LevelStaticData>(LEVEL_STATIC_DATA)
                .ToDictionary(x => x.LevelKey, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeId enemyTypeId) =>
            _enemies.TryGetValue(enemyTypeId, out EnemyStaticData data) ? data : null;

        public LevelStaticData ForLevel(string levelKey) =>
            _levels.TryGetValue(levelKey, out LevelStaticData data) ? data : null;
    }
}