using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Data;
using Wiki.Models;

namespace Wiki.Models
{
    public class PostDetailFullPage
    {
        public PostDetail PostDetail { get; set; }
        public IEnumerable<PostCommentListItem> PostComment { get; set; }
    }
}
