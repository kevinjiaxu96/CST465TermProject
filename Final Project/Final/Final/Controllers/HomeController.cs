using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Final.Models;
using Final.Repositories;
using Final.Models.AccountViewModels;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DefaultSettings _defaultSettings;

        public HomeController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptionsSnapshot<DefaultSettings> settings)
        {
            _defaultSettings = settings.Value;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [HttpGet]
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Profile");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, Name = model.Name};
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    bool ifDefaultRoleExist = await _roleManager.RoleExistsAsync(_defaultSettings.DefaultRole);
                    if (ifDefaultRoleExist == false)
                    {
                        IdentityRole memberRole = new IdentityRole()
                        {
                            Name = _defaultSettings.DefaultRole
                        };
                        await _roleManager.CreateAsync(memberRole);
                    }
                    await _userManager.AddToRoleAsync(user, _defaultSettings.DefaultRole);
                    return RedirectToAction("Login", "Account");
                }
                AddErrors(result);
            }
            return View(model);
        }

        public IActionResult Error()
        {
            return View();
        }

        [Route("/error")]
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
