using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simple_Forum.Models
{
    public class Discuss
    {
        public long id { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public User Author { get; set; }
        [Required]
        public long postIdnum { get; set; }
        [Required]
        public DateTime pubdate { get; set; } = DateTime.Now;
    }
}
