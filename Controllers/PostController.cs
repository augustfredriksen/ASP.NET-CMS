using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oblig2.Models;
using Oblig2.Models.Entities;
using Oblig2.ViewModels;

namespace Oblig2.Controllers
{
    public class PostController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IPostRepository _postRepository;

        public PostController(IBlogRepository blogRepository, IPostRepository postRepository)
        {
            _blogRepository = blogRepository;
            _postRepository = postRepository;
        }

        public IActionResult Index(int id)
        {
            var post = _postRepository.GetPostById(id);
            var comments = _postRepository.GetPostComments(id);
            return View(new PostViewModel(comments, post));
        }

        [Authorize]
        public IActionResult Create(int id)
        {
            ViewBag.Id = id;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([Bind("PostTitle", "Content", "BlogId")]Post post)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                
                {
                    
                }
                var p = new Post();
                p.PostTitle = post.PostTitle;
                p.Content = post.Content;
                p.BlogId = post.BlogId;

                _postRepository.CreatePost(p);
            }
            return RedirectToAction("Index", "Blog", new { id = post.BlogId });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var post = _postRepository.GetPostById(id);
            return View(post);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, [Bind("PostId, PostTitle, Content, BlogId")] Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _postRepository.UpdatePost(post);
                    return RedirectToAction("Index", "Blog", new { id = post.BlogId });
                }
                return new ChallengeResult();
            }
            catch
            {
                return View(post);
            }
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _postRepository.GetPostById(id);
            _postRepository.DeletePost(post);
            return RedirectToAction("Index", "Blog", new { id = post.BlogId });
        }
    }
}
