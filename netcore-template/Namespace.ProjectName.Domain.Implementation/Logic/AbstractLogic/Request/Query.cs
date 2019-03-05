using System;
using Namespace.ProjectName.Domain.Contract.Request;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Request
{
    public class Query<T> : IQuery<T>
    {
        public DateTime Timestamp { get; protected set; }

        protected Query()
        {
            Timestamp = DateTime.Now;
        }
    }
}