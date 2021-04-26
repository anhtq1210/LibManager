using MyLibraryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MyLibraryManager.Repositories
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(LibraryContext context) : base (context)
        {
        }

        public IEnumerable<Request> GetAllRequestByUserID(Guid id, params Expression<Func<Request, object>>[] include)
        {
            return Entities.Include(b => b.User).Include(b => b.RequestDetail).Where(b => b.UserID == id).AsEnumerable();
        }
    }
}
