using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace FirstAPI.Models
{
    public class FirstAPIContext : DbContext
    {
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options) : base(options)
        {
        }

        public DbSet<Rocker> TodoItems { get; set; } = null!;
    }
}
