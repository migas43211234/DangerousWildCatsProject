using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace dangerouswildcats.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the dangerouswildcatsUser class
    public class dangerouswildcatsUser : IdentityUser
    {
        public string FirstName { get; set; }
    }
}
