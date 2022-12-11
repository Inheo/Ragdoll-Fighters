using Scripts.Data;
using UnityEngine;

namespace CodeBase.Service.PersistentProgress
{
    public class PersistentProgressService : MonoBehaviour, IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}