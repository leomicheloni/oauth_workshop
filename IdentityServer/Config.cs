using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
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