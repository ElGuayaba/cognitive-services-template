using Microsoft.EntityFrameworkCore;
using NetcoreTemplate.Domain.Entity;
using NetcoreTemplate.Persistence.Contract.Repository;
using NetcoreTemplate.Persistence.Implementation.Context;

namespace NetcoreTemplate.Persistence.Implementation.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(NetcoreTemplateDbContext dbContext) : base(dbContext)
        {
        }
    }
}