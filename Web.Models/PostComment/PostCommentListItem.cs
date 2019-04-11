using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models
{
    public class PostCommentListItem
    {
        public int CommentId { get; set; }
        public string CommentCatagory { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
