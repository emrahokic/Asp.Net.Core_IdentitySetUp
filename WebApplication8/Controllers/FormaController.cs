using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication8.ViewModels;

namespace WebApplication8.Controllers
{
    public class FormaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create(FormaVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.Drzava != null && model.Adresa != null )
                {
                    return RedirectToAction(nameof(Details), model);
                }
            }
            List<string> s = new List<string>();

            s.Add("Kladusa");
            s.Add("Mostar");
            s.Add("Sarajevo");
            s.Add("Cazin");
            s.Add("Bihac");

            List<SelectListItem> listagradova = new List<SelectListItem>();
            listagradova.AddRange(s.Select(x => new SelectListItem()
            {
                Value = new Random().Next().ToString(),
                Text = x
            })); ;

            model.ListaGradova = listagradova;
            return View(model);
        }

        public IActionResult Details(FormaVM model)
        {
            return View(model);
        }
    }
}