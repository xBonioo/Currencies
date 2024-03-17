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
        var _dbContext = services.GetRequiredService<TableContext>();
        if (!_dbContext.Database.CanConnect())
        {
            return;
        }

        var db = _dbContext.Database;
        try
        {
            var pendingMigrations = db.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                db.Migrate();
            }
        }
        catch (Exception ex)
        {
            // Handle exception
        }
    }
}
