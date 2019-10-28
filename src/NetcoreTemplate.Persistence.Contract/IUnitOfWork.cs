using System.Threading;
using System.Threading.Tasks;
using NetcoreTemplate.Persistence.Contract.Repository;

namespace NetcoreTemplate.Persistence.Contract
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }
        IProfileRepository ProfileRepository { get; set; }
        
        Task SaveAsync(CancellationToken cancellationToken = default);
    }
}