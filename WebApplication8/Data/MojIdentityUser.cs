using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication8.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MojIdentityUser class
    public class MojIdentityUser : IdentityUser
    {
        public string  FirstName { get; set; }

        public string  LastName { get; set; }
        public byte[] Slika { get; set; }
        public char  Gander { get; set; }
    }
}
