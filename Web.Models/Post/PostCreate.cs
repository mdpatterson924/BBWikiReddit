using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Models
{
    public class PostCreate
    {
        [Required]
        public string Catagory { get; set; }
        public string Text { get; set; }
    }
}
