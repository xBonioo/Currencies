using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Currencies.Models.EntityConfiguration;

public class UserExchangeHistoryEntityConfiguration : IEntityTypeConfiguration<UserExchangeHistory>
{
    public void Configure(EntityTypeBuilder<UserExchangeHistory> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasOne(u => u.User)
            .WithMany(u => u.UserExchangeHistory)
            .HasForeignKey(u => u.UserID);

        builder
            .HasOne(u => u.FromCurrency)
            .WithMany()
            .HasForeignKey(u => u.FromCurrencyID);

        builder
            .HasOne(u => u.ToCurrency)
            .WithMany()
            .HasForeignKey(u => u.ToCurrencyID);

        builder
            .Property(u => u.Amount)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();

        builder
            .Property(u => u.ExchangeRate)
            .HasColumnType("decimal(18, 6)") 
            .IsRequired();
    }
}