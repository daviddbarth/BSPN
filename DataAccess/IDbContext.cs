using System;
using System.Data.Entity;

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

        DbSet<T> Set<T>()
        where T : class;
    }
}