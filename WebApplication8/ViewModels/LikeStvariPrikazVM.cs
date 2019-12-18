using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication8.Models;

namespace WebApplication8.ViewModels
{
    public class LikeStvariPrikazVM
    {
        public List<RoW> LikeStvari { get; set; }

        public LikeStvariPrikazVM()
        {
            LikeStvari = new List<RoW>();
        }
        public class RoW
        {
            public int PetID { get; set; }
            public string NazivPeta { get; set; }
            public string Naziv { get; set; }
        }
    }
}
