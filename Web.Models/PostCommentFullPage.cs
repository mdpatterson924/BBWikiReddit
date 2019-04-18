using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Models;
using Wiki.Models.Thread;

namespace Web.Models
{
    public class PostCommentFullPage
    {
        public PostCommentDetail PostCommentDetail { get; set; }
        public IEnumerable<ThreadListItem> ThreadComment { get; set; }
    }
}
