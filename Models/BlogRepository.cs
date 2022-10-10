using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Oblig2.Models.Entities;
using Oblig2.ViewModels;
using System.Security.Principal;

namespace Oblig2.Models
{
    public class BlogRepository: IBlogRepository
    {
        private readonly ApplicationDbContext _oblig2DbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public BlogRepository(UserManager<IdentityUser> userManager, ApplicationDbContext oblig2DbContext)
        {
            _oblig2DbContext = oblig2DbContext;
            _userManager = userManager;
        }

        public IEnumerable<Blog> GetAllBlogs => _oblig2DbContext.Blogs.OrderBy(b => b.BlogName);

        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            return _oblig2DbContext.Posts.Where(p => p.Blog.BlogId == blogId);
        }

        public Blog GetBlogById(int blogId)
        {
            return _oblig2DbContext.Blogs.First(b => b.BlogId == blogId);
        }

        public async Task CreateBlog(Blog blog, IPrincipal principal)
        {
            var currentUser = await _userManager.FindByNameAsync(principal.Identity.Name);
            blog.UserId = currentUser.Id;

            _oblig2DbContext.Blogs.Add(blog);
            _oblig2DbContext.SaveChanges();
        }
    }
}
