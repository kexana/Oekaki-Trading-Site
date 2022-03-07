using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Controllers
{
    public class DrawController : Controller
    {
        [HttpGet]
        public IActionResult Draw()
        {
            return View();
        }
        public IActionResult DrawSetup()
        {

            return View();
        }
        public IActionResult DrawPublish()
        {

            return View();
        }
    }
}
