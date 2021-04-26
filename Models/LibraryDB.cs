using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyLibraryManager.Models{
       public class LibraryContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Request> Requests { get; set; }

        public DbSet<RequestDetail> RequestDetails { get; set; }

        public LibraryContext(DbContextOptions options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RequestDetail>().HasKey(x => new {x.BookID, x.RequestID});

            var user1 = new User { ID = Guid.NewGuid() , UserName = "admin", Passwords = "123", Role = UserRole.SuperUser, Created = DateTime.Now };
            var user2 = new User { ID = Guid.NewGuid() , UserName = "AnhTQ", Passwords = "123", Role = UserRole.User, Created = DateTime.Now };
           

            builder.Entity<User>().HasData(
                user1,
                user2
            );
            var cate1 = new Category { ID = Guid.NewGuid(), Name = "Math", Created = DateTime.Now };
            var cate2 = new Category { ID = Guid.NewGuid(), Name = "Literature", Created = DateTime.Now };

            builder.Entity<Category>().HasData(
                cate1,
                cate2
            );

            var book1 = new Book { ID = Guid.NewGuid(), Name = "Math 11", Author = "NXB", CategoryID = cate1.ID, Created = DateTime.Now };
            var book2 = new Book { ID = Guid.NewGuid(), Name = "Math 12", Author = "NXB", CategoryID = cate1.ID, Created = DateTime.Now };
            var book3 = new Book { ID = Guid.NewGuid(), Name = "Literatue 12", Author = "NXB", CategoryID = cate2.ID, Created = DateTime.Now };
           
            builder.Entity<Book>().HasData(
                book1,
                book2,
                book3
            );
        }
            public async Task<int> SaveChangesAsync()
        {
            Audit();
            return await base.SaveChangesAsync();
        }

        private void Audit()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
            ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
}
}