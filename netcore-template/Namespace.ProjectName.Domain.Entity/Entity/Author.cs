using System.Collections.Generic;

namespace Namespace.ProjectName.Domain.Entity.Entity
{
    public class Author : AbstractEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pseudonim { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        
        public IEnumerable<Blog> Blogs { get; set; }
    }
}