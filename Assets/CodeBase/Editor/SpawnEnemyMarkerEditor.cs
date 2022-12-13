using UnityEngine;
using UnityEditor;
using CodeBase.Logic.EnemySpawner;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(SpawnEnemyMarker))]
    public class SpawnEnemyMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RendererCustGizmo(SpawnEnemyMarker spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawner.transform.position, 0.5f);
        }
    }
}