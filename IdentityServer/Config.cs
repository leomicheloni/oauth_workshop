using IdentityModel;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
                new ApiResource("API1")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                new Client
                {
                    ClientId = "client.credentials",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new [] { new Secret ("client.secret".ToSha256()) },
                    AllowedScopes = new [] { "API1" }
                }
            };
    }
}