using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Energy.DataAccess.ContextClasses;
using Energy.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Energy.DataAccess.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DatabaseContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public bool Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);

            var result = Save();

            return result > 0;
        }

        public bool AddRange(List<T> entities)
        {
            _dbContext.Set<T>().AddRange(entities);

            var result = Save();

            return result > 0;
        }

        public T Get<TKey>(TKey id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public bool Any(Expression<Func<T, bool>> whereCondition)
        {
            return _dbSet.Any(whereCondition);
        }

        public bool All(Expression<Func<T, bool>> whereCondition)
        {
            return _dbSet.All(whereCondition);
        }

        public void Update(T entity)
        {
            Save();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);

            Save();
        }

        public void DeleteRange(List<T> entities)
        {
            _dbSet.RemoveRange(entities);

            Save();
        }

        private int Save()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    entry.Reload();
                }

                return _dbContext.SaveChanges();
            }
        }
    }
}