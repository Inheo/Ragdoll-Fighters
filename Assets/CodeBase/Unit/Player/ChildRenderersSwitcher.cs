using UnityEngine;

namespace CodeBase.Unit.Player
{
    public class ChildRenderersSwitcher : MonoBehaviour
    {
        private Renderer[] _renderers;

        [ContextMenu("Switch")]
        private void Switch()
        {
            if (_renderers == null || _renderers.Length == 0)
            {
                _renderers = GetComponentsInChildren<Renderer>();
            }

            for (var i = 0; i < _renderers.Length; i++)
            {
                _renderers[i].enabled = !_renderers[i].enabled;
            }
        }
    }
}