using Microsoft.AspNetCore.Identity;
using Oblig2.Models.Entities;
using Oblig2.ViewModels;
using System.Security.Principal;

namespace Oblig2.Models
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetAllBlogs { get; }

        IEnumerable<Post> GetBlogPosts(int blogId);

        Blog GetBlogById(int blogId);

        Task CreateBlog (Blog blog, IPrincipal principal);
    }
}
