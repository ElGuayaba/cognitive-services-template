using System.Threading.Tasks;
using NetcoreTemplate.Api.WebApi.Service.Implementation;

namespace NetcoreTemplate.Api.WebApi.Service.Contract
{
    public interface IJwtTokenService
    {
        Task<JwtToken> Generate(string userId);
    }
}