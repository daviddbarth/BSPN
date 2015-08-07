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
        void Attach(T entity);
        T Create();
        void Entry(T entity, EntityState state);
        T Find(int id);
        IEnumerable<T> FindAll();
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);
        T FindOneOrCreate(Expression<Func<T, bool>> predicate);
        T FindOne(Expression<Func<T, bool>> predicate);
        void Remove(T obj);
    }

    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly IDbContext _context;
        private readonly IDbSet<T> _dbSet;

        public Repository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual T Create()
        {
            var newEntity = Activator.CreateInstance<T>();
            _dbSet.Add(newEntity);
            return newEntity;
        }

        public virtual void Attach(T entity)
        {
            _dbSet.Attach(entity);
        }

        public virtual void Entry(T entity, EntityState state)
        {
            _context.Entry(entity).State = state;
        }

        public virtual T Find(int id)
        {
            return _dbSet.Find(new object[] { id });
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public virtual IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where<T>(predicate);
        }

        public virtual T FindOneOrCreate(Expression<Func<T, bool>> predicate)
        {
            var t = _dbSet.FirstOrDefault<T>(predicate) ?? Create();

            return t;
        }

        public virtual T FindOne(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault<T>(predicate);
        }
        
        public virtual void Remove(T obj)
        {
            _context.Set<T>().Remove(obj);
        }
    }
}