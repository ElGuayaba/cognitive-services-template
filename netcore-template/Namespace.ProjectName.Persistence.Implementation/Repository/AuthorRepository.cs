using Namespace.ProjectName.Domain.Entity.Entity;
using Namespace.ProjectName.Persistence.Contract.Repository;
using Namespace.ProjectName.Persistence.Implementation.Context;

namespace Namespace.ProjectName.Persistence.Implementation.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ProjectNameDbContext dbContext) : base(dbContext)
        {
        }
    }
}