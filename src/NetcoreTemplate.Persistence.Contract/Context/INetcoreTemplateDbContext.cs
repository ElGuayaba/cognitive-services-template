using Microsoft.EntityFrameworkCore;
using NetcoreTemplate.Domain.Entity;

namespace NetcoreTemplate.Persistence.Contract.Context
{
    public interface INetcoreTemplateDbContext : IDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Profile> Profile { get; set; }
    }
}