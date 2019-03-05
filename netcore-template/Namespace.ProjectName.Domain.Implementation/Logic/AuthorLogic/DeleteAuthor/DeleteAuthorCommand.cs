using System;
using Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Request;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AuthorLogic.DeleteAuthor
{
    public class DeleteAuthorCommand : Command
    {
        public Guid Id { get; set; }
    }
}