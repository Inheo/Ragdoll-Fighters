using CodeBase.StaticData;

namespace CodeBase.Service.StaticData
{
    public interface IStaticDataService
    {
        EnemyStaticData ForEnemy(EnemyTypeId enemyTypeId);
        LevelStaticData ForLevel(string levelKey);
    }
}