using Microsoft.AspNetCore.Mvc;
using OekakiTradingSite.Models;
using OekakiTradingSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentService commentService;
        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Comment> comments = commentService.GetAll();
            return View(comments);
        }
        [HttpPost]
        public IActionResult PostComment(string Contents, int drawingPostId)
        {
            Comment comment = new Comment(Contents, 0, drawingPostId, DateTime.Now);
            commentService.AddComment(comment);
            return RedirectToAction("ViewPost","PostsBrowser", new { id =drawingPostId });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Comment comment= commentService.FindById(id);
            return View(comment);
        }
        [HttpPost]
        public IActionResult AlterInfo(int id, string contents)
        {
            Comment comment = new Comment(contents, 0, 0, DateTime.Now);
            commentService.EditComment(comment,id);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            commentService.DeleteComment(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
