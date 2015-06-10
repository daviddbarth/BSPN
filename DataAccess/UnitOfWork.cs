using System;
using System.Collections.Concurrent;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ConcurrentDictionary<Guid, IDbContext> _contexts;

        public UnitOfWork(IDbContext context)
        {
            _contexts = new ConcurrentDictionary<Guid, IDbContext>();
            _contexts.TryAdd(context.ContextId, context);
        }

        public void Commit()
        {
            foreach (var context in _contexts.Values)
            {
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            foreach (var context in _contexts.Values)
            {
                context.Dispose();
            }
        }

        public void Rollback()
        {
            foreach (var context in _contexts.Values)
            {
                context.Rollback();
            }
        }
    }

}
