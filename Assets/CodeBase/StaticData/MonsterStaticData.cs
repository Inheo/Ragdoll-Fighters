using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "Satic Data/Level")]
    public class MonsterStaticData : ScriptableObject
    {
        [Range(1f, 100f)] public float HealthPoint = 20;
        [Range(0.1f, 5f)] public float AttackReload = 0.7f;
        [Range(0.1f, 20f)] public float AttackDistance = 2f;
        [Range(0.1f, 20f)] public float MoveSpeed = 5;

        public AssetReferenceGameObject PrefabReference;
    }
}