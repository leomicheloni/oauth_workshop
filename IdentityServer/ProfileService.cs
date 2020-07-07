using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string subject = context.Subject.Claims.ToList().Find(s => s.Type == "sub").Value;
            try
            {
                ICollection<Claim> claimList = TestUsers.Users.FirstOrDefault(u => u.SubjectId == subject)?.Claims;
                if (claimList == null)
                {
                    return Task.FromResult(0);
                }
                context.IssuedClaims = claimList.Where(x => context.RequestedClaimTypes.Contains(x.Type)).ToList();
                return Task.FromResult(0);
            }
            catch
            {
                return Task.FromResult(0);
            }
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            return Task.FromResult(0);
        }
    }
}
