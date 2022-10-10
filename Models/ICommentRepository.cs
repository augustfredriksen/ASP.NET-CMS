using Oblig2.Models.Entities;
using System.Security.Principal;

namespace Oblig2.Models
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int? id);
        Task CreateComment(Comment comment, IPrincipal principal);
        void UpdateComment(Comment comment);
        void DeleteComment(Comment comment);
    }
}
