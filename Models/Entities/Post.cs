using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Oblig2.Models.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        [StringLength(50)]
        public string PostTitle { get; set; }
        [StringLength(500)]
        public string Content { get; set; }
        public List<Comment>? Comments { get; set; }
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }
    }
}
