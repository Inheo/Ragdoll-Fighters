using Scripts.Data;
using UnityEngine;

namespace CodeBase.Service.PersistentProgress
{
    public class PersistentProgressService : IPersistentProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}