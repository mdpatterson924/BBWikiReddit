using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models
{
    public class PostCommentEdit
    {
        public int PostCommentId { get; set; }
        public string Catagory { get; set; }
        public string Text { get; set; }
    }
}
