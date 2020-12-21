using Microsoft.EntityFrameworkCore;

namespace ISP_Lab18
{
    class UsersDbContext : DbContext
    {

        public UsersDbContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UsersDb;Trusted_Connection=True;");
        }
    }
}
