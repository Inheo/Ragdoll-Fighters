public interface ITargetSetHandler
{
    public ITargetSetEmitter TargetSetEmitter { get; }

    public void GetTargetSetEmitter(ITargetSetEmitter targetSetEmitter);

    void SetTarget(Unit target);
}