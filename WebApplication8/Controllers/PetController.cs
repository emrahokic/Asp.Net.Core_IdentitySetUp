using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Models;
using WebApplication8.ViewModels;
using static WebApplication8.helpers.Helpers;

namespace WebApplication8.Controllers
{
    public class PetController : Controller
    {
        private readonly MojIdentityContext _db;

        public PetController(MojIdentityContext dbContext)
        {
            _db = dbContext;
        }
        public IActionResult Index()
        {

            PetVM pets = new PetVM();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            pets.Pets = _db.Pet.Where(x=>x.UserID == int.Parse(userId)).Select(x => new PetVM.RoW()
            {
                Naziv=x.Naziv,
                DatumRodjenja=x.DatumRodjenja.ToString("dd.MM.yyyy"),
                PetID=x.PetID,
                Vrsta=x.vrsta.ToString(),
                BrojLikeStvari= _db.LikeStvari.Where(y => y.PetID==x.PetID).Count()
            }).ToList();

            return View(pets);
        }

        public IActionResult Dodaj()
        {
            return View(new PetToSaveVM());
        }

        [HttpPost]
        public IActionResult Dodaj(PetToSaveVM model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Pet pet = new Pet()
            {
                UserID = int.Parse(userId),
                DatumRodjenja=model.DatumRodjenja,
                Naziv=model.Naziv,
                vrsta=(Vrsta)model.vrsta
            };
            _db.Pet.Add(pet);
            _db.SaveChanges();
            return RedirectToActionPermanent(nameof(Index));
        }
        public IActionResult DodajLikeStvari()
        {
            var vm = new LikeStvariVM();
            return View();
        }
    }
}