using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace IdsWithAspIds.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the IdsWithAspIdsUser class
    public class IdsWithAspIdsUser : IdentityUser
    {
        [PersonalData]
        public string GivenName { get; set; }

        [PersonalData]
        public string Surname { get; set; }
        //public string FamilyName { get; set; }

        [PersonalData]
        public string Role { get; set; }
    }
}
