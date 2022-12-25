using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public class Panels : MonoBehaviour
    {
        [SerializeField] private FadePanel _winPanel;
        [SerializeField] private FadePanel _failPanel;
        [SerializeField] private Button _winButton;
        [SerializeField] private Button _failButton;

        public Button WinButton => _winButton;
        public Button FailButton => _failButton;

        private void Start()
        {
            FastHideAll();
        }

        public void ShowWinPanel() => _winPanel.Show();
        public void ShowFailPanel() => _failPanel.Show();

        public void FastHideAll()
        {
            _winPanel.Hide(true);
            _failPanel.Hide(true);
        }
    }
}