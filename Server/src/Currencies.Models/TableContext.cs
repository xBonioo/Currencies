using Currencies.Common.Infrastructure;
using Currencies.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Currencies.Models;

public class TableContext : IdentityDbContext<
        ApplicationUser, IdentityRole, string,
        IdentityUserClaim<string>,
        IdentityUserRole<string>,
        IdentityUserLogin<string>,
        IdentityRoleClaim<string>,
        TokenUser>
{
    public virtual DbSet<Currency> Currencies => Set<Currency>();
    public virtual DbSet<ExchangeRate> ExchangeRate => Set<ExchangeRate>();
    public virtual DbSet<UserExchangeHistory> UserExchangeHistories => Set<UserExchangeHistory>();
    public virtual DbSet<UserCurrencyAmount> UserCurrencyAmounts => Set<UserCurrencyAmount>();
    public virtual DbSet<Role> Roles => Set<Role>();

    public TableContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.StateChanged += Timestamps;
        ChangeTracker.Tracked += Timestamps;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TableContext).Assembly);

        var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                                     .SelectMany(t => t.GetForeignKeys())
                                     .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade);

        foreach (var fk in cascadeFKs)
        {
            fk.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);

        TestDataSeed(modelBuilder);
    }

    private void Timestamps(object? sender, EntityEntryEventArgs e)
    {
        if (sender is null)
        {
            return;
        }
        if (e.Entry.Entity is ICreatable createdEntity &&
            e.Entry.State == EntityState.Added)
        {
            createdEntity.CreatedOn = DateTime.UtcNow;
        }
        else if (e.Entry.Entity is IModifable modifiedEntity &&
        e.Entry.State == EntityState.Modified)
        {
            modifiedEntity.ModifiedOn = DateTime.UtcNow;
        }
    }

    private void TestDataSeed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "Użytkownik"
                });


        modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = 1,
                    Name = "Dolar",
                    Symbol = "$",
                    Description = "Waluta w USA"
                },
                new Currency
                {
                    Id = 2,
                    Name = "Euro",
                    Symbol = "€",
                    Description = "Waluta w niektórych krajach UE"
                },
                new Currency
                {
                    Id = 3,
                    Name = "Funt",
                    Symbol = "£",
                    Description = "Waluta w UK"
                },
                new Currency
                {
                    Id = 4,
                    Name = "Polska złotówka",
                    Symbol = "PLN",
                    Description = "Waluta w Polsce"
                });
    }
}