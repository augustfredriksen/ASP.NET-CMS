using Oblig2.Models;
using Oblig2.Models.Entities;
using Oblig2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Configuration;

namespace Oblig2.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogController(IBlogRepository blogRepository, UserManager<IdentityUser> userManager)
        {
            _blogRepository = blogRepository;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create([Bind("BlogName, Description")]Blog blog)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var b = new Blog();
                b.BlogName = blog.BlogName;
                b.Description = blog.Description;

                _blogRepository.CreateBlog(b, User).Wait();
            }
            return RedirectToAction(controllerName: "Home", actionName: "Index");
        }

        public async Task<IActionResult> Index(int id)
        {
            Blog blog = _blogRepository.GetBlogById(id);
            var posts = _blogRepository.GetBlogPosts(id);
            IdentityUser blogOwner = await _userManager.FindByIdAsync(blog.UserId);

            return View(new BlogViewModel(posts, blog, blogOwner));
        }
    }
}
