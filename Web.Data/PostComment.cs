using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Data
{
    public class PostComment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string CommentText { get; set; }
        [Required]
        public Guid EditorId { get; set; }
        [Required]
        public string  CommentCatagory { get; set; }
    }
}
