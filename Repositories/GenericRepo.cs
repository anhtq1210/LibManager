using MyLibraryManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace MyLibraryManager.Repositories
{
    /// <summary>
    /// General repository class async
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        
        protected readonly LibraryContext Context;
        protected readonly DbSet<T> Entities;
        public GenericRepository(LibraryContext context)
        {
            this.Context = context;
            Entities = context.Set<T>();
        }
         public IEnumerable<T> GetOne(Guid id, params Expression<Func<T, object>>[] include)
        {
            var query = Entities.AsQueryable();
            return include.Aggregate(query, (current, include) => current.Include(include)).Where(s => s.ID == id);
        }
            public async Task<IEnumerable<T>> GetAll()
        {
            return await Entities.ToListAsync();
        }
        public IEnumerable<T> GetAllInclude(params Expression<Func<T, object>>[] include)
        {
            var query = Entities.AsQueryable();
            return include.Aggregate(query, (current, include) => current.Include(include));
            throw new NotImplementedException();
        }

     public async Task<T> GetOneByID(Guid predicate)
        {
            return await Entities.SingleOrDefaultAsync(b => b.ID == predicate);
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await Entities.AddAsync(entity);
            Context.SaveChanges();

        }

        public async Task Remove(Object id)
        {
            T entity = await Entities.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Entities.Remove(entity);
            Context.SaveChanges();
           
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }


}
