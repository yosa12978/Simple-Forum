using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simple_Forum.Models
{
    public class Category
    {
        public long id { get; set; }
        [Required]
        public string title { get; set; }
        public List<Post> posts { get; set; }
    }
}
