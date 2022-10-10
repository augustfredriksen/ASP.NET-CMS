using Microsoft.AspNetCore.Mvc;
using Oblig2.Models;
using Oblig2.ViewModels;

namespace Oblig2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public HomeController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public IActionResult Index()
        {
            var allBlogs = _blogRepository.GetAllBlogs;

            var homeViewModel = new HomeViewModel(allBlogs);

            return View(homeViewModel);
        }
    }
}