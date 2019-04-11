using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models
{
    public class PostCommentDetail
    {
        public int CommentId { get; set; }
        public string CommentCatagory { get; set; }
        public string CommentText { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{CommentId}] {CommentCatagory}";
    }
}
