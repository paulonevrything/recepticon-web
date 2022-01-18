using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Recepticon.Persistence.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Delete(int id);
        Task<bool> Upsert(T entity);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
    }
}
