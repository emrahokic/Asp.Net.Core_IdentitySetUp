using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApplication8.Models;

namespace WebApplication8.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MojIdentityUser class
    public class MojIdentityUser : IdentityUser<int>
    {
        public string  FirstName { get; set; }
        public string  LastName { get; set; }
        public char  Gander { get; set; }

        public List<Pet> Pets { get; set; } 
    }
}
