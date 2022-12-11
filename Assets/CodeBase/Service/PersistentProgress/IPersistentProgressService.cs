using Scripts.Data;

namespace CodeBase.Service.PersistentProgress
{
    public interface IPersistentProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}