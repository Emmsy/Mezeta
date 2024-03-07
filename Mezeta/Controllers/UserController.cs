using Microsoft.AspNetCore.Authorization;
using Mezeta.Core.Models.User;
using Microsoft.AspNetCore.Mvc;
using Mezeta.Infrastructure.Data.Entities;
using Mezeta.Core.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Mezeta.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly SignInManager<User> signInManager;

        public UserController(IUserService _userService, SignInManager<User> _signInManager)
        {
            userService = _userService;
            signInManager = _signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await userService.CreateUser(model);

            return RedirectToAction("Login", "User");
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var crtUser = await (userService.ReturnUser(model));

            if (crtUser==null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            var result = await signInManager.PasswordSignInAsync(crtUser.UserName,crtUser.PasswordHash,false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

        }
    }
}
