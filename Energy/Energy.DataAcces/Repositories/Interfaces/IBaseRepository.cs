using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Energy.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        bool Add(T entity);

        bool AddRange(List<T> entities);

        T Get<TKey>(TKey id);

        IQueryable<T> GetAll();

        bool Any(Expression<Func<T, bool>> whereCondition);

        bool All(Expression<Func<T, bool>> whereCondition);

        public void Update(T entity);

        public void Delete(T entity);

        void DeleteRange(List<T> entities);
    }
}