using Domex.Core.Application.DTOs.Account;

namespace Domex.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task SingOutAsync();
    }
}