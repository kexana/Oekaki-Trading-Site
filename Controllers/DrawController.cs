using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OekakiTradingSite.Models;
using OekakiTradingSite.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Controllers
{
    public class DrawController : Controller
    {
        private IDrawService drawService;
        private ICommentService commentService;
        private UserManager<User> userManager; 
        public DrawController(IDrawService drawService, ICommentService commentService, UserManager<User> userManager)
        {
            this.drawService = drawService;
            this.commentService = commentService;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Drawing> drawings = drawService.GetAll();

            return View(drawings);
        }
        [HttpGet]
        public IActionResult Draw()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DrawSetup()
        {

            return View();
        }
        [HttpGet]
        public IActionResult DrawPublish()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DrawPublish(Drawing drawing)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            drawService.AddDrawing(drawing, user);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Drawing drawing = drawService.FindById(id);

            return View(drawing);
        }
        [HttpPost]
        public IActionResult AlterInfo(Drawing drawing)
        {
            drawService.EditInfo(drawing);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id) {
            drawService.DeleteDrawing(id);
            commentService.DeleteAllCommentsOnDrawingId(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
