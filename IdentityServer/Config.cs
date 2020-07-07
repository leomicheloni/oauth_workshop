using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

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
                },
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = false,
                    RequireClientSecret = false,
                    RequireConsent = false,

                    RedirectUris =           { "http://localhost:5003/callback.html" },
                    PostLogoutRedirectUris = { "http://localhost:5003/index.html" },
                    AllowedCorsOrigins =     { "http://localhost:5003" },

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "API1"
                    }
                },
                new Client
                {
                    ClientId = "ro.client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = new [] { new Secret ("client.secret".ToSha256()) },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "API1"
                    }
                }
            };
    }
}