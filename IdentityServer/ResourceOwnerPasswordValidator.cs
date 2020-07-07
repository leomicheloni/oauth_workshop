using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public ResourceOwnerPasswordValidator()
        {
        }

        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = TestUsers.Users.FirstOrDefault(u=>u.Username == context.UserName);
            if (user != null && user.Password == context.Password)
            {
                context.Result = new GrantValidationResult
                (
                    subject: user.SubjectId,
                    authenticationMethod: "custom"
                );

            }
            else
            {
                context.Result = new GrantValidationResult(
                       TokenRequestErrors.InvalidGrant,
                       "invalid custom credential");
            }

            return Task.FromResult(0);
        }
    }
}
