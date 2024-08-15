using Cosmo.Services.ComboBoxAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cosmo.Services.ComboBoxAPI.Configuration
{
    public class ComboConfiguration : IEntityTypeConfiguration<Combo>
    {
        public void Configure(EntityTypeBuilder<Combo> builder)
        {
            builder.HasKey(c => c.ComboId);
            builder
                .HasMany(c => c.Products)
                .WithMany(p => p.Combos);
        }
    }
}
