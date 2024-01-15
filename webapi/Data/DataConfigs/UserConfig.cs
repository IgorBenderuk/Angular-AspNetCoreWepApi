using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using webapi.models;

namespace webapi.Data.DataConfigs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.id);

            builder.HasMany(u => u.Lots)
                .WithOne(lot => lot.Owner)
                .HasForeignKey(lot => lot.OwnerId);

        }
    }
}
