using Oblig2.Models.Entities;

namespace Oblig2.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Blog> AllBlogs { get; }

        public HomeViewModel(IEnumerable<Blog> allBlogs)
        {
            AllBlogs = allBlogs;
        }
    }
}
