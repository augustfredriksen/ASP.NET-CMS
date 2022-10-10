using Oblig2.Models.Entities;
using System.Security.Principal;

namespace Oblig2.Models
{
    public interface IPostRepository
    {
        IEnumerable<Comment> GetPostComments(int postId);
        Post GetPostById(int? id);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
    }
}
