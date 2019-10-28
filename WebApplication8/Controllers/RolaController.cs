using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication8.Areas.Identity.Data;
using WebApplication8.Models;

namespace WebApplication8.Controllers
{
    public class RolaController : Controller
    {
        private readonly UserManager<MojIdentityUser> _userManager;
        private readonly SignInManager<MojIdentityUser> _signInManager;
        private readonly MojIdentityContext _ctx;

        public RolaController(MojIdentityContext context, SignInManager<MojIdentityUser> signInManager,UserManager<MojIdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ctx = context;
        }
        public async Task<IActionResult> Dodaj(string ReturnUrl)
        {

            if (ReturnUrl != "" && ReturnUrl != null)
            {
                
                var user = await _userManager.GetUserAsync(User);

                await _userManager.AddToRoleAsync(user, "Admin");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return LocalRedirect(ReturnUrl);
            }
            return RedirectToAction();
        }
    }
}