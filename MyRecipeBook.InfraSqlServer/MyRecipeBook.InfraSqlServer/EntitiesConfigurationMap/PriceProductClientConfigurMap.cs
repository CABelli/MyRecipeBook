using MyRecipeBook.InfraSqlServer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyRecipeBook.InfraSqlServer.EntitiesConfigurationMap
{
    public class PriceProductClientConfigurMap : IEntityTypeConfiguration<PriceProductClient>
    {
        public void Configure(EntityTypeBuilder<PriceProductClient> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(p => p.ProductValue);
            builder.Property(p => p.DateValidate);
            builder.Property(p => p.IdProduct);
        }
    }
}
