using System.Threading.Tasks;
using Namespace.ProjectName.Persistence.Contract.Repository;

namespace Namespace.ProjectName.Persistence.Contract
{
    public interface IUnitOfWork
    {
        IAuthorRepository AuthorRepository { get; set; }
        IBlogRepository BlogRepository { get; set; }
        IPostRepository PostRepository { get; set; }
        
        Task SaveAsync();

    }
}