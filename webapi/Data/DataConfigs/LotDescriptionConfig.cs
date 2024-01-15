using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.models;

namespace webapi.Data.DataConfigs
{
    public class LotDescriptionConfig : IEntityTypeConfiguration<LotDescription>
    {
        public void Configure(EntityTypeBuilder<LotDescription> builder)
        {
            builder.HasKey(d => d.id);

            builder.HasOne(d => d.Lot)
                .WithOne(l => l.Description)
                .HasForeignKey<LotDescription>(l => l.LotID);

            builder.HasMany(desc => desc.Photos)
                .WithOne(photo => photo.LotDescription)
                .HasForeignKey(photo => photo.Lotid);

        }
    }
}
