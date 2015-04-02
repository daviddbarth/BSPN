using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ConcurrentDictionary<Guid, IDbContext> _contexts;

        public UnitOfWork(IDbContext context)
        {
            this._contexts = new ConcurrentDictionary<Guid, IDbContext>();
            this._contexts.TryAdd(context.ContextId, context);
        }

        public void Commit()
        {
            foreach (IDbContext context in this._contexts.Values)
            {
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            foreach (IDbContext context in this._contexts.Values)
            {
                context.Dispose();
            }
        }

        public void Rollback()
        {
            foreach (IDbContext context in this._contexts.Values)
            {
                context.Rollback();
            }
        }
    }

}
