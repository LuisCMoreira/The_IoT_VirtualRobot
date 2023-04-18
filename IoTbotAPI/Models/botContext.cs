using Microsoft.EntityFrameworkCore;

namespace IoTbotAPI.Models
{
    public class botContext : DbContext
    {
        public botContext(DbContextOptions<botContext> options)
        : base(options)
        {
        }

        public DbSet<JT1Control> JT1Control { get; set; } = null!;

        public DbSet<JT2Control> JT2Control { get; set; } = null!;

        public DbSet<JT3Control> JT3Control { get; set; } = null!;

        public DbSet<JT4Control> JT4Control { get; set; } = null!;

        public DbSet<JT5Control> JT5Control { get; set; } = null!;

        public DbSet<JT6Control> JT6Control { get; set; } = null!;
    }
}