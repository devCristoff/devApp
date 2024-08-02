using Swashbuckle.AspNetCore.Annotations;
using System.Xml.Serialization;

namespace Vimenpaq.Core.Application.DTOs.Account
{
    /// <summary>
    /// Parameters to perform user authentication
    /// </summary> 
    [XmlRoot("AuthenticationRequest")]
    public class AuthenticationRequest
    {
        [SwaggerParameter(Description = "Email of the user to be logged in ")]
        [XmlElement("email")]
        public string Email { get; set; }

        [SwaggerParameter(Description = "Password of the user to be logged in ")]
        [XmlElement("password")]
        public string Password { get; set; }
    }
}
