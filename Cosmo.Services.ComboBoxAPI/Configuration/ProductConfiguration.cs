using Cosmo.Services.ComboBoxAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cosmo.Services.ComboBoxAPI.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.ProductId);
            builder
                .HasMany(p => p.Combos)
                .WithMany(c => c.Products);
        }
    }
}
