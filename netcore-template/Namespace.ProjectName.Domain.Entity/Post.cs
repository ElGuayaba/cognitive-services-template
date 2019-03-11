using System;

namespace Namespace.ProjectName.Domain.Entity
{
    public class Post : BaseEntity, IAggregateRoot
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        
        public Blog Blog { get; set; }
    }
}