using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace simple_Forum.Models
{
    public class User
    {
        public long id { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string token { get; set; }
        [Required]
        public DateTime reg_date { get; set; } = DateTime.UtcNow;
        [Required]
        public bool IsLoggedNow { get; set; }
        [Required]
        public string Role { get; set; }
        public string icon { get; set; } = "/Default.PNG";
    }
}
