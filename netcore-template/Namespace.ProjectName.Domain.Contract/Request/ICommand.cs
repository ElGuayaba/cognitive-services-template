using System;
using MediatR;
using Namespace.ProjectName.Domain.Contract.Model;

namespace Namespace.ProjectName.Domain.Contract.Request
{
    public interface ICommand : IRequest<CommandResult>
    {
        DateTime Timestamp { get; }
    }
}