using Namespace.ProjectName.Domain.Contract;

namespace Namespace.ProjectName.Persistence.Contract.Repository
{
    public interface IAbstractGenericRepository<T> where T : IAggregateRoot
    {
        
    }
}