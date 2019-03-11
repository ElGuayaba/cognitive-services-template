using System;
using System.Threading.Tasks;
using Namespace.ProjectName.Application.Contract.Dto;
using Namespace.ProjectName.Common.Model;

namespace Namespace.ProjectName.Application.Contract.Service
{
    public interface IAuthorService
    {
        Task<Result<AuthorDto>> Find(Guid id);
        Task<Result<Guid>> Create(string name, string surname, string pseudonim, string email, DateTime birthDate);
        Task<Result<Guid>> Update(Guid id, string name, string surname, string pseudonim, string email, DateTime birthDate);
        Task<Result<Guid>> Delete(Guid id);
    }
}