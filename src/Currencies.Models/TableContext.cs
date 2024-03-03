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
}