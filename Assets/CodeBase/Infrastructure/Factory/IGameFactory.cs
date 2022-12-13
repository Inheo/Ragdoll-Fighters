using System.Threading.Tasks;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory
    {
        GameObject Player { get; }
        GameObject Enemy { get; }

        Task<GameObject> CreateEnemy(EnemyTypeId enemyTypeId, Vector3 at);
        Task<GameObject> CreatePlayer(Vector3 at);
    }
}