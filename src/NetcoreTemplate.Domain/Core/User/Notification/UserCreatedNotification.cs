using MediatR;

namespace NetcoreTemplate.Domain.Core.User.Notification
{
    public class UserCreatedNotification : INotification
    {
        public string UserId { get; set; }
    }
}