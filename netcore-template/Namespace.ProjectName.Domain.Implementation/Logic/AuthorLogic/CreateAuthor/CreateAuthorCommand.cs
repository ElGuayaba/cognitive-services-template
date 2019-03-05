using Namespace.ProjectName.Domain.Implementation.Logic.AbstractLogic.Request;

namespace Namespace.ProjectName.Domain.Implementation.Logic.AuthorLogic.CreateAuthor
{
    public class CreateAuthorCommand : Command
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pseudonim { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
    }
}