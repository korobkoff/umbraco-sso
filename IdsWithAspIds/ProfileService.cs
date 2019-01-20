using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using System;
using System.Threading.Tasks;
using IdentityServer4.Models;
//using IdentityAuthority.Models;
using Microsoft.AspNetCore.Identity;
using IdentityServer4.Extensions;
using System.Linq;
using IdsWithAspIds.Areas.Identity.Data;
using System.Security.Claims;
using IdentityModel;

namespace IdsWithAspIds
{
    public class ProfileService : IProfileService
    {
        protected UserManager<IdsWithAspIdsUser> _userManager;

        public ProfileService(UserManager<IdsWithAspIdsUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //>Processing
            var user = await _userManager.GetUserAsync(context.Subject);

            var claims = new List<Claim>
        {
            new Claim(JwtClaimTypes.Email, "Email"),
            new Claim(JwtClaimTypes.GivenName, "GivenName"),
            new Claim(JwtClaimTypes.FamilyName, "FamilyName"),
            new Claim(JwtClaimTypes.Name, "Name"),
            new Claim(JwtClaimTypes.Role, "Standard User"),
            //new Claim("GivenName", user.GivenName),
            //new Claim("Surname", user.Surname),
            //new Claim("Email", user.Email)

        };

            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            //>Processing
            var user = await _userManager.GetUserAsync(context.Subject);

            //context.IsActive = (user != null) && user.IsActive;
        }
    }
}
