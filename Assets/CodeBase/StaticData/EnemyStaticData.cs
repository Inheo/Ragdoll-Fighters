using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "Static Data/Enemy")]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyTypeId EnemyTypeId;
        [Range(1f, 100f)] public float HealthPoint = 20;
        [Range(0.1f, 5f)] public float AttackCooldown = 0.7f;
        [Range(0.1f, 20f)] public float AttackDistance = 2f;
        [Range(0.1f, 20f)] public float AttackDamage = 2f;
        [Range(0.1f, 20f)] public float MoveSpeed = 5;

        public AssetReferenceGameObject PrefabReference;
    }
}