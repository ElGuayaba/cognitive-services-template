using System;
using System.Collections.Generic;

namespace Namespace.ProjectName.Domain.Entity
{
    public class Author : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pseudonim { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        
        public Blog Blog { get; set; }
    }
}