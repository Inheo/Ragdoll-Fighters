using UnityEngine;
using TMPro;

namespace Assets.CodeBase.Logic.Other
{
    public class RandomNickName : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nickNameText;

        private void Start()
        {
            SetNickName();
        }

        private void SetNickName()
        {
            TextAsset namesAsset = Resources.Load<TextAsset>("TextFiles/names");
            string[] names = namesAsset.text.Split("\n");
            string name = names[Random.Range(0, names.Length)];

            _nickNameText.text = name;
        }
    }
}