using Swashbuckle.AspNetCore.Annotations;

namespace Fedex.Core.Application.DTOs.Account
{
    /// <summary>
    /// Parameters to perform user authentication
    /// </summary> 
    public class AuthenticationRequest
    {
        [SwaggerParameter(Description = "Email of the user to be logged in ")]
        public string Email { get; set; }

        [SwaggerParameter(Description = "Password of the user to be logged in ")]
        public string Password { get; set; }
    }
}
