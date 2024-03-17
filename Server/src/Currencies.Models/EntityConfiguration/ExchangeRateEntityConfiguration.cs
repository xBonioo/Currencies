using Currencies.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Currencies.Models.EntityConfiguration;

public class ExchangeRateEntityConfiguration : IEntityTypeConfiguration<ExchangeRate>
{
    public void Configure(EntityTypeBuilder<ExchangeRate> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasOne(e => e.FromCurrency)
            .WithMany()
            .HasForeignKey(e => e.FromCurrencyID);

        builder
            .HasOne(e => e.ToCurrency)
            .WithMany()
            .HasForeignKey(e => e.ToCurrencyID);

        builder
            .Property(r => r.Rate)
            .HasColumnType("decimal(18, 6)")
            .IsRequired();

        builder
            .HasOne(er => er.FromCurrency)
            .WithMany()
            .HasForeignKey(er => er.FromCurrencyID);

        builder
            .HasOne(er => er.ToCurrency)
            .WithMany()
            .HasForeignKey(er => er.ToCurrencyID);
    }
}
