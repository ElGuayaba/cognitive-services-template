using System;
using Microsoft.EntityFrameworkCore;
using NetcoreTemplate.Domain.Entity;
using NetcoreTemplate.Persistence.Contract.Context;

namespace NetcoreTemplate.Persistence.Implementation.Context
{
    public class NetcoreTemplateDbContext : DbContext, INetcoreTemplateDbContext
    {
        public DbContext Instance => this;
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        
        protected NetcoreTemplateDbContext()
        {
        }

        public NetcoreTemplateDbContext(DbContextOptions<NetcoreTemplateDbContext> options) : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                throw new ArgumentException("Database not properly configured");
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NetcoreTemplateDbContext).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }

    }
}