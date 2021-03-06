using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Model
{
    public class postDBContext : DbContext
    {
        public postDBContext(DbContextOptions<postDBContext> options) : base(options)        {        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<user> users { get; set; }
    }
}
