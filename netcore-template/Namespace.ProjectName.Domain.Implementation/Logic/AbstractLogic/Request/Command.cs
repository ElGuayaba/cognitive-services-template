using System;
using Namespace.ProjectName.Domain.Contract.Request;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Request
{
    public abstract class Command : ICommand
    {
        public DateTime Timestamp { get; protected set; }
        
        protected Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}