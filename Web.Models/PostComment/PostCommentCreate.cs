using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models
{
    public class PostCommentCreate
    {
        [Required]
        public string CommentCatagory { get; set; }
        public string CommentText { get; set; }
    }
}
