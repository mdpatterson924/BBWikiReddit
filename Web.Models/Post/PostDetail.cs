using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models
{
    public class PostDetail
    {
        public int PostId { get; set; }
        public string Catagory { get; set; }
        public string Text { get; set; }
        [Display (Name= "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display (Name ="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
        public override string ToString() => $"[{PostId}] {Catagory}";
    }
}
