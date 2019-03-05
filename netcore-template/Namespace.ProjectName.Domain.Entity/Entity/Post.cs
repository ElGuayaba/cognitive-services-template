using System;

namespace Namespace.ProjectName.Domain.Entity.Entity
{
    public class Post : AbstractEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        
        public Blog Blog { get; set; }
    }
}