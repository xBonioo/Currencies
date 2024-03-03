using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Currencies.Models.EntityConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
             .Property(r => r.FirstName)
             .HasMaxLength(64)
             .IsRequired();

        builder
             .Property(r => r.LastName)
             .HasMaxLength(64)
             .IsRequired();

        builder
            .HasMany(r => r.UserExchangeHistory)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserID);
    }
}
