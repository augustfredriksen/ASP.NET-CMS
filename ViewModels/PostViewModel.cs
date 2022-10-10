using Microsoft.AspNetCore.Identity;
using Oblig2.Models.Entities;
using System.Reflection.Metadata;

namespace Oblig2.ViewModels
{
    public class PostViewModel
    {
        public IEnumerable<Comment> Comments { get; }

        public Post Post { get; }

        public PostViewModel(IEnumerable<Comment> comments, Post post)
        {
            Comments = comments;
            Post = post;
        }
    }
}
