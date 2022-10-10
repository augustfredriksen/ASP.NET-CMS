using Microsoft.AspNetCore.Identity;
using Oblig2.Models.Entities;

namespace Oblig2.ViewModels
{
    public class BlogViewModel
    {
        public IEnumerable<Post> Posts { get; }

        public Blog Blog { get; }

        public IdentityUser BlogOwner { get; }

        public BlogViewModel(IEnumerable<Post> posts, Blog blog, IdentityUser blogOwner)
        {
            Posts = posts;
            Blog = blog;
            BlogOwner = blogOwner;
        }
    }
}
