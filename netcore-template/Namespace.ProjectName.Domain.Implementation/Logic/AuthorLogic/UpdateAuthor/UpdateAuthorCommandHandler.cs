using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Namespace.ProjectName.Domain.Contract.Model;
using Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Handler;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AuthorLogic.UpdateAuthor
{
    public class UpdateAuthorCommandHandler : CommandHandler<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandHandler(ILogger<CommandHandler<UpdateAuthorCommand>> logger) : base(logger)
        {
        }

        public override Task<CommandResult> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}