using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class UserManagementContext: IdentityDbContext
    { 
        public DbSet<Pets> Pets  { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public UserManagementContext(DbContextOptions<UserManagementContext> options):base(options) { }
    }
}
