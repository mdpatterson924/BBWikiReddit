using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models
{
    public class PostCommentEdit
    {
        public int CommentId { get; set; }
        public string CommentCatagory { get; set; }
        public string CommentText { get; set; }
    }
}
