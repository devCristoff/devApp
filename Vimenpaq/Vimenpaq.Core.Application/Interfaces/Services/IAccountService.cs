using Vimenpaq.Core.Application.DTOs.Account;

namespace Vimenpaq.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task SingOutAsync();
    }
}