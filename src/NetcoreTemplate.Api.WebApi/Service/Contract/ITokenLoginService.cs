using System;
using System.Threading.Tasks;
using NetcoreTemplate.Api.WebApi.Identity;

namespace NetcoreTemplate.Api.WebApi.Service.Contract
{
    public interface ITokenLoginService
    {
        Task<string> GenerateToken(string userId);
        Task<LoginToken> RecoverLoginToken(Guid token);
    }
}