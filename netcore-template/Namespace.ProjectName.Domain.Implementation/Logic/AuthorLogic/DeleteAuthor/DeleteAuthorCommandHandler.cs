using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Namespace.ProjectName.Domain.Contract.Model;
using Namespace.ProjectName.Domain.Implementation.Exception;
using Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Handler;
using Namespace.ProjectName.Persistence.Contract;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AuthorLogic.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : CommandHandler<DeleteAuthorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(ILogger<CommandHandler<DeleteAuthorCommand>> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<CommandResult> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.AuthorRepository.FindById(request.Id);

            if (author == null)
            {
                throw new NotFoundException(request.Id);
            }
            
            _unitOfWork.AuthorRepository.Delete(author);

            await _unitOfWork.SaveAsync();
            
            return new CommandResult
            {
                Successful = true
            };
        }
    }
}