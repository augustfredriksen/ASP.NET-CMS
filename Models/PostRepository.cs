using Microsoft.AspNetCore.Identity;
using Oblig2.Models.Entities;
using System.Security.Principal;

namespace Oblig2.Models
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext _oblig2DbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public PostRepository(ApplicationDbContext oblig2DbContext, UserManager<IdentityUser> userManager)
        {
            _oblig2DbContext = oblig2DbContext;
            _userManager = userManager;
        }

        public IEnumerable<Comment> GetPostComments(int postId)
        {
            return _oblig2DbContext.Comments.Where(c => c.PostId == postId);
        }
             
        public Post GetPostById(int? id)
        {
            return _oblig2DbContext.Posts.First(p => p.PostId == id);
        }

        public void CreatePost(Post post)
        {
            _oblig2DbContext.Posts.Add(post);
            _oblig2DbContext.SaveChanges();
        }

        public void DeletePost(Post post)
        {
            _oblig2DbContext.Posts.Remove(post);
            _oblig2DbContext.SaveChanges();
        }

        public void UpdatePost(Post post)
        {
            _oblig2DbContext.Posts.Update(post);
            _oblig2DbContext.SaveChanges();
        }
    }
}
