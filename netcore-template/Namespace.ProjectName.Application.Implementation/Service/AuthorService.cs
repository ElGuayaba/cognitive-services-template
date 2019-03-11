using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Namespace.ProjectName.Application.Contract.Dto;
using Namespace.ProjectName.Application.Contract.Service;
using Namespace.ProjectName.Application.Implementation.Mapping;
using Namespace.ProjectName.Common.Model;
using Namespace.ProjectName.Domain.Implementation.BusinessLogic.AuthorLogic.CreateAuthor;
using Namespace.ProjectName.Domain.Implementation.BusinessLogic.AuthorLogic.DeleteAuthor;
using Namespace.ProjectName.Domain.Implementation.BusinessLogic.AuthorLogic.FindAuthor;
using Namespace.ProjectName.Domain.Implementation.BusinessLogic.AuthorLogic.UpdateAuthor;

namespace Namespace.ProjectName.Application.Implementation.Service
{
    public class AuthorService : IAuthorService
    {
        protected readonly IMediator MediatR;
        protected readonly ILogger<AuthorService> Logger;

        public AuthorService(IMediator mediatR, ILogger<AuthorService> logger)
        {
            MediatR = mediatR;
            Logger = logger;
        }

        public async Task<Result<AuthorDto>> Find(Guid id)
        {
            try
            {
                var result = await MediatR.Send(new FindAuthorQuery
                {
                    Id = id
                });
            
                if (result.HasValidationErrors())
                {
                    return Result<AuthorDto>.ValidationFail(result.ValidationFailures);
                }

                if (result.HasNotBeenFound())
                {
                    return Result<AuthorDto>.NotFound(result.Message);
                }
            
                if (result.IsForbidden())
                {
                    return Result<AuthorDto>.Forbidden(result.Message);
                }

                return Result<AuthorDto>.Success(result.Value.ToAuthorDto());
            }
            catch (Exception e)
            {
                Logger.LogError("Unhandled error finding author", e);
                
                return Result<AuthorDto>.UnknownError();
            }
        }

        public async Task<Result<Guid>> Create(string name, string surname, string pseudonim, string email, DateTime birthDate)
        {
            try
            {
                var result = await MediatR.Send(new CreateAuthorCommand
                {
                    Name = name,
                    Surname = surname,
                    Pseudonim = pseudonim,
                    Email = email,
                    BirthDate = birthDate
                });

                if (result.IsSuccessful())
                {
                    //Raise event to send email to user, etc.
                }

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError("Unhandled error creating author", e);
                
                return Result<Guid>.UnknownError();
            }
        }

        public async Task<Result<Guid>> Update(Guid id, string name, string surname, string pseudonim, string email, DateTime birthDate)
        {
            try
            {
                var result = await MediatR.Send(new UpdateAuthorCommand
                {
                    Name = name,
                    Surname = surname,
                    Pseudonim = pseudonim,
                    Email = email,
                    BirthDate = birthDate
                });

                if (result.IsSuccessful())
                {
                    //Raise event to send email to user, etc.
                }

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError("Unhandled error updating author", e);
                
                return Result<Guid>.UnknownError();
            }
        }

        public async Task<Result<Guid>> Delete(Guid id)
        {
            try
            {
                var result = await MediatR.Send(new DeleteAuthorCommand
                {
                    Id = id
                });

                if (result.IsSuccessful())
                {
                    //Raise event to send email to user, etc.
                }

                return result;
            }
            catch (Exception e)
            {
                Logger.LogError("Unhandled error deleting author", e);
                
                return Result<Guid>.UnknownError();
            }
        }
    }
}