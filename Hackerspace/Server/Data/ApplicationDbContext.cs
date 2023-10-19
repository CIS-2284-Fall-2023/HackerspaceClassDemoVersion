using Hackerspace.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackerspace.Server.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; }

        public ApplicationDbContext(string connectionString)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, connectionString);
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
