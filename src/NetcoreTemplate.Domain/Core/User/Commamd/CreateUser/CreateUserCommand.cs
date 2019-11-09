using MediatR;

namespace NetcoreTemplate.Domain.Core.User.Commamd.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string UserId { get; set; }
    }
}