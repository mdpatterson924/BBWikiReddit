using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models.Thread
{
    public class ThreadCreate
    {
        public Guid EditorId { get; set; }
        public string Text { get; set; }
        public int PostCommentId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
