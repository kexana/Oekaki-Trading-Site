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
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            List<User> users = userService.GetAll(); 
            return View(users);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(User user)
        {
            userService.CreateUser(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            userService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(userService.FindById(id));
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            userService.Edit(user);
            return RedirectToAction(nameof(Index));
        }

 

    }
}
