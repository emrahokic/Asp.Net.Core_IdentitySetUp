using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication8.helpers.Helpers;

namespace WebApplication8.ViewModels
{
    public class PetVM
    {
        public List<RoW> Pets { get; set; }

        public PetVM()
        {
            Pets = new List<RoW>();
        }
        public class RoW
        {
            public int PetID { get; set; }
            public string Naziv { get; set; }
            public string DatumRodjenja { get; set; }
            public string Vrsta { get; set; }
            public int BrojLikeStvari { get; set; }
        }
        
    }
}
