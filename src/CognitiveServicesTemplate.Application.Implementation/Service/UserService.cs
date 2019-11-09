using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using CognitiveServicesTemplate.Application.Contract.Service;
using CognitiveServicesTemplate.Common.ErrorHandling;
using CognitiveServicesTemplate.Domain.Core.User.Commamd.CreateUser;
using CognitiveServicesTemplate.Domain.Core.User.Query.FindUser;
using OperationResult;
using static OperationResult.Helpers;

namespace CognitiveServicesTemplate.Application.Implementation.Service
{
    public class UserService : IUserService
    {
        protected readonly ILogger<UserService> Logger;
        protected readonly IMediator Mediator;

        public UserService(ILogger<UserService> logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        public async Task<Status<Error>> Create(string userId, CancellationToken cancellationToken = default)
        {
            await Mediator.Send(new CreateUserCommand {UserId = userId}, cancellationToken);

            var user = await Mediator.Send(new FindUserQuery {UserId = userId}, cancellationToken);

            if (user.IsError)
            {
                return Error(user.Error);
            }

            return Ok();
        }
    }
}