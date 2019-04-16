using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models.Thread
{
    public class ThreadListItem
    {
        public int ThreadId { get; set; }
        public string Text { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
