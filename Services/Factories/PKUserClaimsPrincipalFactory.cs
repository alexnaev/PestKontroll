using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PestKontroll.Models;
using System.Security.Claims;

namespace PestKontroll.Services.Factories
{
    public class PKUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<PKUser, IdentityRole>
    {
        public PKUserClaimsPrincipalFactory(UserManager<PKUser> userManager, RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> optionsAccessor)
            : base(userManager, roleManager, optionsAccessor) 
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(PKUser user)
        {
            ClaimsIdentity identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("CompanyId", user.CompanyId.ToString()));
            
            return identity;
        }
    }
}
