using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Final.Models
{
    public class UserManagementContext: IdentityDbContext<Users,IdentityRole,string>
    {
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Pets> Pets { get; set; }
        public UserManagementContext(DbContextOptions<UserManagementContext> options):base(options) { }
    }
}
