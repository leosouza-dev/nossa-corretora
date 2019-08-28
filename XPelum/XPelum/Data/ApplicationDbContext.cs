using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using XPelum.Models;

namespace XPelum.Data
{
    public class ApplicationDbContext : IdentityDbContext<Cliente>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cliente>().Ignore(c => c.AccessFailedCount)
                                   .Ignore(c => c.LockoutEnabled)
                                   .Ignore(c => c.TwoFactorEnabled);
      
            builder.Entity<Cliente>().ToTable("Clientes");//to change the name of table.

        }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
