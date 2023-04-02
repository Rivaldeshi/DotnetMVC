using TestAplication.Models;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.EntityFrameworkCore;

namespace TestAplication.DAL
{

    public class UserContext : DbContext
    {

        public UserContext()
        { }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Name = "rivaldes", SurName = "ranol" });
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Name = "john", SurName = "paul" });
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Name = "mike", SurName = "marie" });
            modelBuilder.Entity<User>().HasData(new User { Id = Guid.NewGuid(), Name = "durelle", SurName = "Melong" });
        }

    }

}
