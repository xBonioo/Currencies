using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Currencies.Models.EntityConfiguration;

public class CurrencyAmountEntityConfiguration : IEntityTypeConfiguration<CurrencyAmount>
{
    public void Configure(EntityTypeBuilder<CurrencyAmount> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasOne(uc => uc.Currency)
            .WithMany()
            .HasForeignKey(uc => uc.CurrencyId);

        builder
            .Property(u => u.Amount)
            .HasColumnType("decimal(18, 2)")
            .IsRequired();
    }
}