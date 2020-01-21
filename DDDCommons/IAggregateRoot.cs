namespace DDDCommons
{
    public interface IAggregateRoot<TIdentity, TState>
        where TIdentity : Identity<TIdentity>
        where TState : struct
    {
        TState State { get; }
    }
}