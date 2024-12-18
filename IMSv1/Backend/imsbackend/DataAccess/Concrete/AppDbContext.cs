using Microsoft.EntityFrameworkCore;
using imsbackend.Entities;
using imsbackend.Entities.Concrete;

namespace imsbackend.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Immovable> Immovables { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}