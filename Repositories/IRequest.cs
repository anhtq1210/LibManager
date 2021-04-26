using MyLibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyLibraryManager.Repositories
{
    public interface IRequestRepository : IGenericRepository<Request>
    {
        IEnumerable<Request> GetAllRequestByUserID(Guid id, params Expression<Func<Request, object>>[] include);
    }
}