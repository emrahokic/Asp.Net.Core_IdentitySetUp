using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Areas.Identity.Data;
using static WebApplication8.helpers.Helpers;

namespace WebApplication8.Models
{
    public class Pet
    {
        public int PetID { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Vrsta vrsta { get; set; }

        public int UserID { get; set; }
        public MojIdentityUser User { get; set; }

        public List<LikeStvari> LikeStvari { get; set; }
    }
}
