using System;
using Namespace.ProjectName.Domain.Entity.Entity;
using Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Request;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AuthorLogic.FindAuthor
{
    public class FindAuthorQuery : Query<Author>
    {
        public Guid Id { get; set; }
    }
}