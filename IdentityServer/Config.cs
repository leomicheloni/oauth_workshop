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
            };

        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
            };
    }
}