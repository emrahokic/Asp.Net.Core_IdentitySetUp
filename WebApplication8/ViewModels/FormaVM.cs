using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.ViewModels
{
    public class FormaVM
    {
        public int GradId { get; set; }
        [Required]
        public string Drzava { get; set; }
        [Required]
        public string Adresa { get; set; }
        public List<SelectListItem> ListaGradova { get; set; }
    }
}
