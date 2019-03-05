using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Request;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Handler
{
    public abstract class QueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : Query<TResponse>
    {
        protected readonly ILogger<QueryHandler<TRequest, TResponse>> Logger;

        protected QueryHandler(ILogger<QueryHandler<TRequest, TResponse>> logger)
        {
            Logger = logger;
        }

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}