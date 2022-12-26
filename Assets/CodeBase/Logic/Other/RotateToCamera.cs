using UnityEngine;

namespace CodeBase.Logic.Other
{
    public class RotateToCamera : MonoBehaviour
    {
        private void Update()
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}