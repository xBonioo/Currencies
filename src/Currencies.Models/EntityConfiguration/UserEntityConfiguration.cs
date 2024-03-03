using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Currencies.Models.EntityConfiguration;

public class UserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
             .Property(r => r.FirstName)
             .HasMaxLength(64);

        builder
             .Property(r => r.SecondName)
             .HasMaxLength(64);

        builder
             .Property(r => r.UserName)
             .HasMaxLength(64)
             .IsRequired();

        builder
            .HasMany(u => u.CurrencyAmounts)
            .WithOne(uc => uc.User)
            .HasForeignKey(uc => uc.UserId);

        builder
            .HasMany(r => r.UserExchangeHistory)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserID);

        builder
            .HasMany(u => u.UserExchangeHistory)
            .WithOne(ueh => ueh.User)
            .HasForeignKey(ueh => ueh.UserID);
    }
}
