using CodeBase.Service.PersistentProgress;
using Scripts.Data;
using UnityEngine;

namespace CodeBase.Service.SaveLoad
{
    public class SaveLoadService : MonoBehaviour, ISaveLoadService
    {
        private const string PROGRESS_KEY = "Progress";

        private readonly IPersistentProgressService _progressService;

        // TODO: Inject
        public SaveLoadService(IPersistentProgressService progressService)
        {
            _progressService = progressService;
        }

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