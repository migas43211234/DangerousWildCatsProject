using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dangerouswildcats.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dangerouswildcats.Models;

namespace dangerouswildcats.Data
{
    public class AuthDbContext : IdentityDbContext<dangerouswildcatsUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<dangerouswildcatsRoles> dangerouswildcatsRoles { get; set; }
    }
}
