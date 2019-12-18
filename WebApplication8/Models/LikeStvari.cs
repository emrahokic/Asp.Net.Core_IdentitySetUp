using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Areas.Identity.Data;

namespace WebApplication8.Models
{
    public class LikeStvari
    {
        public int LikeStvariID { get; set; }
        public string Naziv { get; set; }

        public int PetID { get; set; }
        public Pet Pet { get; set; }

    }
}
