using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Recepticon.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Find(int id);
        IQueryable<T> List(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
    }
}
