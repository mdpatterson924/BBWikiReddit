using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models.Thread
{
    public class ThreadDetail
    {
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{ThreadId}]";
        public int PostCommentId { get; set; }
    }
}
