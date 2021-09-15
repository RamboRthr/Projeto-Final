using Microsoft.EntityFrameworkCore;

namespace Projeto_Final.Models
{
    public class UserManagementContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Pets> Pets { get; set; }
        public UserManagementContext(DbContextOptions<UserManagementContext> options) : base(options) { }
    }
}
