using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using BowlPicks.Api.Entity;
using BowlPicks.Api.Entity.Model;

namespace BowlPicks.Api.Data
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
        T GetSingle(Expression<Func<T, bool>> query, IEnumerable<string> includePaths = null);
        IQueryable<T> Get(Expression<Func<T, bool>> query, IEnumerable<string> includePaths = null, bool disableTracking = false);
        IQueryable<T> GetAll();
        IQueryable<T> GetAllNoTracking();
        IEnumerable<T> LoadAll();
        bool Any(Expression<Func<T, bool>> filter);
        IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters);
        void RemoveRange(IQueryable<T> range);
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly BowlPicksContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(BowlPicksContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAllNoTracking()
        {
            return GetAll().AsNoTracking();
        }

        public virtual IEnumerable<T> LoadAll()
        {
            return GetAll().AsNoTracking().ToArray();
        }

        public T GetSingle(Expression<Func<T, bool>> filter, IEnumerable<string> includePaths = null)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includePaths != null)
            {
                query = includePaths.Aggregate(query, (current, includePath) => current.Include(includePath));
            }

            T result = query.SingleOrDefault();
            return result;
        }

        public bool Any(Expression<Func<T, bool>> filter)
        {
            if (filter == null) return false;
            return _dbSet.Any(filter);
        }

        public IEnumerable<T> ExecWithStoreProcedure(string query, params object[] parameters)
        {
            return _context.Database.SqlQuery<T>(query, parameters);
        }

        public void RemoveRange(IQueryable<T> range)
        {
            _dbSet.RemoveRange(range);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter, IEnumerable<string> includePaths = null, bool disableTracking = false)
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includePaths != null)
            {
                query = includePaths.Aggregate(query, (current, includePath) => current.Include(includePath));
            }

            if (disableTracking)
            {
                query.AsNoTracking();
            }

            return query;
        }
    }
}