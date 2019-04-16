using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Data
{
    public class Thread
    {
        public Guid EditorId { get; set; }
        public string Text { get; set; }
        public int ThreadId { get; set; }
        public int PostCommentId { get; set; }
        public DateTimeOffset CreadtedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
