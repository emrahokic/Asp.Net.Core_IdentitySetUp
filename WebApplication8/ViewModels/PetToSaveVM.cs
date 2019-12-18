using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebApplication8.helpers.Helpers;

namespace WebApplication8.ViewModels
{
    public class PetToSaveVM
    {
        public PetToSaveVM()
        {

            _Vrste = new List<SelectListItem>();
            var enumVrste = Enum.GetValues(typeof(Vrsta)).Cast<Vrsta>();

            _Vrste = enumVrste.Select(x => new SelectListItem()
            {
                Text = x.ToString(),
                Value =((int) x).ToString() 
            }).ToList();

        }
        public string Naziv { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int vrsta { get; set; }
        public List<SelectListItem> _Vrste { get; set; }
    }
}
