using UnityEngine;
using UnityEditor;
using CodeBase.StaticData;
using CodeBase.Logic.EnemySpawner;
using System.Linq;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string PLAYER_POSITION = "PlayerPosition";
        private const string ENEMY_POSITION = "EnemyPosition";
        private LevelStaticData _levelData;

        private void OnEnable()
        {
            _levelData = target as LevelStaticData;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if(GUILayout.Button("Update Data"))
            {
                _levelData.LevelKey = SceneManager.GetActiveScene().name;
                _levelData.PlayerPosition = GameObject.FindWithTag(PLAYER_POSITION).transform.position;
                _levelData.EnemyData.Position = GameObject.FindWithTag(ENEMY_POSITION).transform.position;
            }

            EditorUtility.SetDirty(_levelData);
        }
    }
}