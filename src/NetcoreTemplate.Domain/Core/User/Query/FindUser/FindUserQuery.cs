using MediatR;
using NetcoreTemplate.Common.ErrorHandling;
using OperationResult;

namespace NetcoreTemplate.Domain.Core.User.Query.FindUser
{
    public class FindUserQuery : IRequest<Result<Entity.User, Error>>
    {
        public string UserId { get; set; }
    }
}