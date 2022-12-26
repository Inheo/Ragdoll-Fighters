using CodeBase.Service.PersistentProgress;
using CodeBase.Data;
using UnityEngine;
using Zenject;

namespace CodeBase.Service.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PROGRESS_KEY = "Progress";

        [Inject] public readonly IPersistentProgressService _progressService;

        public void SaveProgress()
        {
            PlayerPrefs.SetString(PROGRESS_KEY, _progressService.Progress.ToJson());
        }

        public PlayerProgress LoadProgress()
        {
            return PlayerPrefs.GetString(PROGRESS_KEY)?.ToDeserialized<PlayerProgress>();
        }
    }
}