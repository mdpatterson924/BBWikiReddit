using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models
{
    public class PostListItem
    {
        public int PostId { get; set; }
        public string Catagory { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
