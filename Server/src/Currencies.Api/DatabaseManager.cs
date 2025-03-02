using Currencies.Contracts.Helpers.Exceptions;
using Currencies.Models;
using Microsoft.EntityFrameworkCore;

namespace Currencies.Api;

public class DatabaseManager
{
    private readonly WebApplicationBuilder _builder;

    public DatabaseManager(WebApplicationBuilder builder)
    {
        _builder = builder;
        ConnectToMsSQL();
    }

    private void ConnectToMsSQL()
    {
        string connectionString = "";
        connectionString = _builder.Configuration.GetConnectionString("Default");
        _builder.Services.AddDbContext<TableContext>((DbContextOptionsBuilder options) =>
        {
            options.UseSqlServer(
                connectionString,
                x => x.MigrationsAssembly("Currencies.Migrations"));
        });
    }

    public void ApplyMigrations(IHost app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<TableContext>();
        if (!dbContext.Database.CanConnect())
        {
            return;
        }

        var db = dbContext.Database;
        try
        {
            var pendingMigrations = db.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                db.Migrate();
            }
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}
