using System.Threading;
using System.Threading.Tasks;
using NetcoreTemplate.Common.ErrorHandling;
using OperationResult;

namespace NetcoreTemplate.Application.Contract.Service
{
    public interface IUserService
    {
        Task<Status<Error>> Create(string userId, CancellationToken cancellationToken = default);
    }
}