using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Namespace.ProjectName.Domain.Entity.Entity;
using Namespace.ProjectName.Domain.Implementation.Exception;
using Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Handler;
using Namespace.ProjectName.Persistence.Contract;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AuthorLogic.FindAuthor
{
    public class FindAuthorQueryHandler : QueryHandler<FindAuthorQuery, Author>
    {
        private readonly IUnitOfWork _unitOfWork;

        public FindAuthorQueryHandler(ILogger<QueryHandler<FindAuthorQuery, Author>> logger, IUnitOfWork unitOfWork) : base(logger)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Author> Handle(FindAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = await _unitOfWork.AuthorRepository.FindById(request.Id);

            if (author == null)
            {
                throw new NotFoundException(request.Id);
            }

            return author;
        }
    }
}