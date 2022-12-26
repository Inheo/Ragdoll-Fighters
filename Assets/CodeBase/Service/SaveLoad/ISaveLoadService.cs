using CodeBase.Data;

namespace CodeBase.Service.SaveLoad
{
    public interface ISaveLoadService
    {
        PlayerProgress LoadProgress();
        void SaveProgress();
    }
}