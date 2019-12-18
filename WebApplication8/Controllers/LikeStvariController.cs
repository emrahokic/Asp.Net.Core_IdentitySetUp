using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication8.Models;
using WebApplication8.ViewModels;

namespace WebApplication8.Controllers
{
    public class LikeStvariController : Controller
    {
        private readonly MojIdentityContext _db;

        //public IActionResult Query(string stvar)
        //{
        //    List<Pet>  pets = _db.LikeStvari.Where(x => x.Naziv.Equals(stvar)).Select(x => x.Pet).ToList();

        //    return View();
        //}
        public LikeStvariController(MojIdentityContext db)
        {
            _db = db;
        }
        public IActionResult Dodaj()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Dodaj(int id,LikeStvariVM model)
        {

            LikeStvari temp = new LikeStvari()
            {
                Naziv = model.Naziv,
                PetID = id
            };

            _db.LikeStvari.Add(temp);
            _db.SaveChanges();
            _db.Dispose();
            return RedirectToActionPermanent("Index","Pet");
        }
        public IActionResult Index(int id)
        {

            LikeStvariPrikazVM like = new LikeStvariPrikazVM();
            
            like.LikeStvari = _db.LikeStvari.Include(x=>x.Pet).Where(x=>x.PetID==id).Select(x => new LikeStvariPrikazVM.RoW()
            {
                Naziv = x.Naziv,
                NazivPeta=x.Pet.Naziv
            }).ToList();
            return View(like);
        }
    }
}