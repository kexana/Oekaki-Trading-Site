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
    public class CommentsController : Controller
    {
        private ICommentService commentService;
        private UserManager<User> userManager;
        public CommentsController(ICommentService commentService, UserManager<User> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Comment> comments = commentService.GetAll();
            return View(comments);
        }
        [HttpPost]
        public async Task<IActionResult> PostComment(Comment comment)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            commentService.AddComment(comment, user);

            return RedirectToAction("ViewPost","PostsBrowser", new { id =comment.DrawingPostId });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Comment comment= commentService.FindById(id);

            return View(comment);
        }
        [HttpPost]
        public IActionResult AlterInfo(Comment comment)
        {
            commentService.EditComment(comment);

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
