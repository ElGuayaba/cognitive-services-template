using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Namespace.ProjectName.Domain.Contract.Model;
using Namespace.ProjectName.Domain.Contract.Request;
using Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Request;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Handler
{
    public abstract class CommandHandler<T> : IRequestHandler<T, CommandResult> where T : ICommand
    {
        protected readonly ILogger<CommandHandler<T>> Logger;

        protected CommandHandler(ILogger<CommandHandler<T>> logger)
        {
            Logger = logger;
        }

        public abstract Task<CommandResult> Handle(T request, CancellationToken cancellationToken);
    }
}