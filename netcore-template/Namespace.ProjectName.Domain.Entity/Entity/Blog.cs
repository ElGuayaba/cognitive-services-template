using System.Collections.Generic;

namespace Namespace.ProjectName.Domain.Entity.Entity
{
    public class Blog : AbstractEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Post> Posts { get; set; }
    }
}