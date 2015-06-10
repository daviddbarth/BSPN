using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DataAccess
{
    public interface IDbContext : IDisposable
    {
        Guid ContextId
        {
            get;
        }

        void Rollback();
        int SaveChanges();
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry Entry(object entity);
    }
}