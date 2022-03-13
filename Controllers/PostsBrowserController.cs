using Microsoft.AspNetCore.Mvc;
using OekakiTradingSite.Models;
using OekakiTradingSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Controllers
{
    public class PostsBrowserController : Controller
    {
        private IDrawService drawService;
        private ICommentService commentService;
        public PostsBrowserController(IDrawService drawService, ICommentService commentService)
        {
            this.drawService = drawService;
            this.commentService = commentService;
        }
        [HttpGet]
        public IActionResult Browse()
        {
            List<Drawing> drawings = drawService.GetAll();

            return View(drawings);
        }
        [HttpGet]
        public IActionResult Like(int id)
        {
            Drawing drawing = drawService.FindById(id);
            drawing.TotalLikes += 1;
            return RedirectToAction(nameof(Browse));
        }
        [HttpGet]
        public IActionResult ViewPost(int id)
        {
            ViewBag.drawing = drawService.FindById(id);
            ViewBag.comments = commentService.GetAll().Where(c => c.DrawingPostId == id).ToList();
            return View();
        }
    }
}
