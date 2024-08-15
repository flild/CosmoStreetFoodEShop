using Cosmo.Services.ComboBoxAPI.Configuration;
using Cosmo.Services.ComboBoxAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cosmo.Services.ComboBoxAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Combo> Combos { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ComboConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            base.OnModelCreating(builder);
        }

    }
}
