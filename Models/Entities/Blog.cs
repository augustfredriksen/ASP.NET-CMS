using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Oblig2.Models.Entities
{
    public class Blog
    {
        [BindNever]
        public int BlogId { get; set; }

        [StringLength(25)]
        public string BlogName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
        public string? UserId { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
