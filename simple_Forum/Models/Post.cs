using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simple_Forum.Models
{
    public class Post
    {
        public long id { get; set; }
        [Required]
        public string title { get; set; }
        public string text { get; set; }
        [Required]
        public DateTime createDate { get; set; } = DateTime.Now;
        [Required]
        public User Author { get; set; }
        [Required]
        public Category category { get; set; }
        public List<Discuss> duscussions { get; set; }
    }
}
