using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace RockersAPI.Models
{
    public class FirstAPIContext : DbContext
    {
        public virtual DbSet<Rocker> Rockers { get; set; }

        public string DbPath { get; }
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "rockers.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
