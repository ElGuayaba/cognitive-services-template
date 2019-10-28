using Microsoft.EntityFrameworkCore;
using NetcoreTemplate.Domain.Entity;
using NetcoreTemplate.Persistence.Contract.Repository;
using NetcoreTemplate.Persistence.Implementation.Context;

namespace NetcoreTemplate.Persistence.Implementation.Repository
{
    public class ProfileRepository : GenericRepository<Profile>, IProfileRepository
    {
        public ProfileRepository(NetcoreTemplateDbContext dbContext) : base(dbContext)
        {
        }
    }
}