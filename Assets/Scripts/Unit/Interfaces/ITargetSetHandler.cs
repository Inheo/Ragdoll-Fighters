public interface ITargetSetHandler
{
    public ITargetSetEmitter TargetSetEmitter { get; }

    void SetTarget(Unit target);
}