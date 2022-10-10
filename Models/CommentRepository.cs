using Microsoft.AspNetCore.Identity;
using Oblig2.Models.Entities;
using System.Security.Principal;

namespace Oblig2.Models
{
    public class CommentRepository: ICommentRepository
    {
        private readonly ApplicationDbContext _oblig2DbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public CommentRepository(ApplicationDbContext oblig2DbContext, UserManager<IdentityUser> userManager)
        {
            _oblig2DbContext = oblig2DbContext;
            _userManager = userManager;
        }

        public Comment GetCommentById(int? id)
        {
            return _oblig2DbContext.Comments.First(c => c.CommentId == id);
        }

        public async Task CreateComment(Comment comment, IPrincipal principal)
        {
            var currentUser = await _userManager.FindByNameAsync(principal.Identity.Name);
            comment.UserId = currentUser.Id;

            _oblig2DbContext.Comments.Add(comment);
            _oblig2DbContext.SaveChanges();
        }

        public void DeleteComment(Comment comment)
        {
            _oblig2DbContext.Comments.Remove(comment);
            _oblig2DbContext.SaveChanges();
        }

        public void UpdateComment(Comment comment)
        {
            _oblig2DbContext.Comments.Update(comment);
            _oblig2DbContext.SaveChanges();
        }
    }
}
