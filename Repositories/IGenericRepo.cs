using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyLibraryManager.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> GetOne(Guid id, params Expression<Func<T, object>>[] include);
        IEnumerable<T> GetAllInclude(params Expression<Func<T, object>>[] include);
        Task<T> GetOneByID(Guid predicate);
        Task Insert(T entity);
        void Update(T entity);
        Task Remove(Object id);
    }
}
