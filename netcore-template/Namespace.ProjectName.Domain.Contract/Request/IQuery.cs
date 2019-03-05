using System;
using MediatR;

namespace Namespace.ProjectName.Domain.Contract.Request
{
    public interface IQuery<T> : IRequest<T>
    {
        DateTime Timestamp { get; }
    }
}