using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
