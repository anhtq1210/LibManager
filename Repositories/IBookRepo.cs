using MyLibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryManager.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetAllByCategoryId(Guid categoryId);
    }
}