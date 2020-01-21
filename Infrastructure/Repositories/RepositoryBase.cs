using System;
using DDDCommons;
using Domain.Visit;
using LiteDB;

namespace Infrastructure.Repositories
{
    public class RepositoryBase
    {
        protected readonly BsonMapper _mapper;
        protected readonly string _collectionName;
        protected readonly string _connectionString;

        protected RepositoryBase()
        {
            _collectionName = GetType().Name.Replace("Repository", "").ToLower();
            _connectionString = "aggregates.db";

            _mapper = BsonMapper.Global;
            _mapper.IncludeFields = true;
            _mapper.SerializeNullValues = true;
            _mapper.IncludeNonPublic = true;
        }

        protected void RegisterType<TIdentity>()
            where TIdentity : Identity<TIdentity>
        {
            _mapper.RegisterType<TIdentity>(
                (id) => id.Value,
                (bson) => (TIdentity) Activator.CreateInstance(typeof(TIdentity), (object) bson.AsGuid)
            );
        }
        
        protected TAggregate Get<TAggregate, TState>(Guid id, Func<TState, TAggregate> mapping)
            where TAggregate:class
            where TState: struct
        {
            using (var db = new LiteRepository(_connectionString, _mapper))
            {
                var state = db.First<StateWrapper<TState>>(
                    sw => sw.Id.Equals(id), _collectionName
                ).State;

                var aggregate = mapping(state);

                return aggregate;
            }
        }
        
        protected void Save<TState>(TState aggregateState, Guid id)
            where TState: struct
        {
            using (var db = new LiteRepository(_connectionString, _mapper))
            {
                var stateWrapped = new StateWrapper<TState>
                {
                    Id = id,
                    State = aggregateState
                };

                db.Upsert(stateWrapped, _collectionName);
            }
        }
    }
}