using CodeBase.Unit;

namespace CodeBase.Unit.Interfaces
{
    public interface ITargetSetHandler
    {
        ITargetSetEmitter TargetSetEmitter { get; }
        void SetTarget(Unit target);
    }
}