using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Namespace.ProjectName.Domain.Contract.Model;
using Namespace.ProjectName.Domain.Entity.Entity;
using Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Handler;
using Namespace.ProjectName.Persistence.Contract;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AuthorLogic.CreateAuthor
{
    public class CreateAuthorCommandHandler : CommandHandler<CreateAuthorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CreateAuthorCommandHandler(ILogger<CommandHandler<CreateAuthorCommand>> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<CommandResult> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = request.Name,
                Surname = request.Surname,
                Pseudonim = request.Pseudonim,
                Email = request.Email,
                BirthDate = request.BirthDate,
            };

            await _unitOfWork.AuthorRepository.Insert(author);
            
//            Logger.LogTrace($"New author added to context with name: {author.Name}");

            await _unitOfWork.SaveAsync();

            return new CommandResult
            {
                Identifier = author.Id,
                Successful = true
            };
        }
    }
}