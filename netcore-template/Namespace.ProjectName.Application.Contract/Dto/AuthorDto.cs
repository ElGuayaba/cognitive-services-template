using System;
using System.Collections.Generic;

namespace Namespace.ProjectName.Application.Contract.Dto
{
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pseudonim { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid Blog { get; set; }
    }
}