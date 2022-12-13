using System;
using UnityEngine;

namespace CodeBase.StaticData
{
    [Serializable]
    public class EnemySpawnerStaticData 
    {
        public EnemyTypeId EnemyTypeId;
        public Vector3 Position;

        public EnemySpawnerStaticData(Vector3 position)
        {
            Position = position;
        }  
    }
}