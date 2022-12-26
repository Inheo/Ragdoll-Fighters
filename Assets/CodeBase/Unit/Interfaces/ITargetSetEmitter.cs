using CodeBase.Unit;

namespace CodeBase.Unit.Interfaces
{
    public interface ITargetSetEmitter
    {
        event System.Action<Unit> OnSetTarget;
    }
}