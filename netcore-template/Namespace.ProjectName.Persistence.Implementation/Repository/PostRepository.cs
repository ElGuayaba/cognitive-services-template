using Namespace.ProjectName.Domain.Entity.Entity;
using Namespace.ProjectName.Persistence.Contract.Repository;
using Namespace.ProjectName.Persistence.Implementation.Context;

namespace Namespace.ProjectName.Persistence.Implementation.Repository
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ProjectNameDbContext dbContext) : base(dbContext)
        {
        }
    }
}