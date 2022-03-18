using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OekakiTradingSite.Models;
using OekakiTradingSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Controllers
{
    public class UserController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        private IDrawService drawService;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IDrawService drawService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.drawService = drawService;
        }

        public IActionResult Index()
        {
            List<User> users = userManager.Users.ToList(); 
            return View(users);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string password, string username)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(username, password,false,false);
            if (result.Succeeded)
            {
                return RedirectToAction("Browse", "PostsBrowser");
            }
            bool WriteFailMessege = true;
            return View(WriteFailMessege);
        }
        [HttpGet]
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string email,string password, string username)
        {
            User user = new User();
            user.UserName = username;
            user.Email = email;
            IdentityResult result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Login));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            User user = await userManager.FindByIdAsync(id.ToString());
            await userManager.DeleteAsync(user);
            return RedirectToAction(nameof(Logout));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();//userService.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            //userService.Edit(user);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UserPage()
        {
            User user = await userManager.GetUserAsync(User);
            ViewBag.name = user.UserName;
            ViewBag.email = user.Email;
            List<Drawing> drawings = drawService.GetAll().Where(c => c.CreatorId == user.Id).ToList();
            return View(drawings);
        }


    }
}
