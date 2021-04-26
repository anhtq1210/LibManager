using MyLibraryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLibraryManager.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base (context)
        {
        }

        public IEnumerable<Book> GetAllByCategoryId(Guid categoryId)
        {
            return Entities.Include(b => b.Category).Where(b => b.CategoryID == categoryId).AsEnumerable();
        }
    }
}
