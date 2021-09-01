using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class UserManagementContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Pets> Pets  { get; set; }
        public UserManagementContext(DbContextOptions<UserManagementContext> options):base(options) { }
    }
}
