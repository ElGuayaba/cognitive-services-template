using System;
using System.Linq;
using Namespace.ProjectName.Application.Contract.Dto;
using Namespace.ProjectName.Common.Model;
using Namespace.ProjectName.Domain.Entity;

namespace Namespace.ProjectName.Application.Implementation.Mapping
{
    public static class AuthorExtension
    {
        public static AuthorDto ToAuthorDto(this Author result)
        {
            return new AuthorDto
            {
                Id = result.Id,
                Name = result.Name,
                Surname = result.Surname,
                Pseudonim = result.Pseudonim,
                Email = result.Email,
                BirthDate = result.BirthDate,
                Blog = result.Blog.Id
            };
        }
        
        
    }
}