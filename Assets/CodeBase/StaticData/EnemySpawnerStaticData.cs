using System;
using UnityEngine;

namespace CodeBase.StaticData
{
    [Serializable]
    public class EnemySpawnerStaticData 
    {
        public Vector3 Position;

        public EnemySpawnerStaticData(Vector3 position)
        {
            Position = position;
        }  
    }
}