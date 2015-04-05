using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T Create();

        T Find(int id);

        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);

        T FindOneOrCreate(Expression<Func<T, bool>> predicate);
    }

    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly IDbContext _context;

        private readonly IDbSet<T> _dbSet;

        public Repository(IDbContext context)
        {
            this._context = context;
            this._dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            this._dbSet.Add(entity);
        }

        public virtual T Create()
        {
            T newEntity = Activator.CreateInstance<T>();
            this._dbSet.Add(newEntity);
            return newEntity;
        }

        public virtual T Find(int id)
        {
            return this._dbSet.Find(new object[] { id });
        }

        public virtual IEnumerable<T> FindAll()
        {
            return this._context.Set<T>();
        }

        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return this._dbSet.Where<T>(predicate);
        }

        public virtual T FindOneOrCreate(Expression<Func<T, bool>> predicate)
        {
            T t = this._dbSet.FirstOrDefault<T>(predicate);
            if (t == null)
            {
                t = this.Create();
            }
            return t;
        }
    }
}