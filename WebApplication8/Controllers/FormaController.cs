using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication8.Models;
using WebApplication8.ViewModels;

namespace WebApplication8.Controllers
{
    [Authorize]
    public class FormaController : Controller
    {
        private readonly MojIdentityContext _ctx;

        public FormaController(MojIdentityContext context)
        {
            _ctx = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]

        public IActionResult Create(int GradId, string DrzavaNaziv, string AdresaNaziv, string NekiName)
        {


            if (DrzavaNaziv != null && AdresaNaziv != null)
            {
                FormaVM model1 = new FormaVM()
                {
                    Adresa = AdresaNaziv + " " +NekiName,
                    Drzava = DrzavaNaziv,
                    GradId = GradId
                };
                DrzavaNaziv = null;
                AdresaNaziv = null;
                GradId = -1;
                return View(nameof(Details), model1);
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
            FormaVM model = new FormaVM();
            model.ListaGradova = listagradova;
            return View(model);
        }
        public IActionResult GetPartialView()
        {
            return PartialView("FormaPartialView");
        }
        public IActionResult Details(FormaVM model)
        {
            return View(model);
        }
    }
}