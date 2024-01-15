using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using webapi.models;

namespace webapi.Data.DataConfigs
{
    public class UserBankConfug : IEntityTypeConfiguration<UserBank>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserBank> builder)
        {
            builder.HasKey(ub => new
            {
                ub.BankID,
                ub.UserID
            });

            builder.HasOne(ub => ub.AccountUser)
                .WithMany(u => u.Banks)
                .HasForeignKey(u => u.UserID);


            builder.HasOne(ub => ub.AccountBank)
                .WithMany(b => b.Accounts)
                .HasForeignKey(ub => ub.BankID);
                

        }

    }
}
