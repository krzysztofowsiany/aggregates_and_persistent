using System;

namespace Infrastructure.Repositories
{
    internal class StateWrapper<TState>
        where TState : struct
    {
        public Guid Id;

        public TState State;
    }
}