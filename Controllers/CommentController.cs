using MessagePack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Oblig2.Models;
using Oblig2.Models.Entities;

namespace Oblig2.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentController(ICommentRepository commentRepository, UserManager<IdentityUser> userManager)
        {
            _commentRepository = commentRepository;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([Bind("CommentText", "PostId")]Comment comment)
        {
            if (ModelState.IsValid)
            {
                {
                    
                }
                var c = new Comment();
                c.CommentText = comment.CommentText;
                c.PostId = comment.PostId;

                _commentRepository.CreateComment(c, User).Wait();
            }
            return RedirectToAction("Index", "Post", new { id = comment.PostId });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var comment = _commentRepository.GetCommentById(id);
            return View(comment);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, [Bind("CommentId, CommentText, PostId, UserId")]Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _commentRepository.UpdateComment(comment);
                    return RedirectToAction("Index", "Post", new { id = comment.PostId });
                }
                else return new ChallengeResult();
            }
            catch
            {
                return View(comment);
            }
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var comment = _commentRepository.GetCommentById(id);
            _commentRepository.DeleteComment(comment);
            return RedirectToAction("Index", "Post", new { id = comment.PostId });
        }
    }
}
