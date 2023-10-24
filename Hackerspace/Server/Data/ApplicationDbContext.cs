using Hackerspace.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackerspace.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; }

        public ApplicationDbContext(DbContextOptions options):base(options)
        {
        }
    }
}
