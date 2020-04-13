using Microsoft.EntityFrameworkCore;
using simple_Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace simple_Forum.Data
{
    public class SFContext : DbContext
    {
        public SFContext(DbContextOptions<SFContext> option) : base(option) { Database.EnsureCreated(); }
        public DbSet<Post> Post { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Discuss> Discuss { get; set; }
        public DbSet<User> User { get; set; }

    }
}
