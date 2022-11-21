using Microsoft.AspNetCore.Authentication;

namespace GameStore.Auth
{
    public class ApiKeyAuthSchemeOptions : AuthenticationSchemeOptions
    {
        public string ApiKey { get; set; } = "SuperSegreto";
    }
}
