using Google.Apis.Auth;
using System.Threading.Tasks;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Services
{
    public interface IAuthJwtService
    {
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(ExternalAuth externalAuth);
        Task<string> GenerateToken(GoogleJsonWebSignature.Payload payload);
        Task<string> GenerateToken(Usuario usuariou);
    }
}
