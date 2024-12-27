using FonTech.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using ILogger = Serilog.ILogger;

namespace FonTech.Api;

/// <inheritdoc />
public class DatabaseHealthCheck(ApplicationDbContext applicationDbContext, ILogger logger) : IHealthCheck
{
    /// <inheritdoc />
    public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            await applicationDbContext.Database.OpenConnectionAsync(cancellationToken: cancellationToken);

            await applicationDbContext.Database.ExecuteSqlRawAsync("SELECT 1", cancellationToken);

            return HealthCheckResult.Healthy();
        }
        catch (Exception ex)
        {
            logger.Error(ex, ex.Message);
            return HealthCheckResult.Unhealthy();
        }
    }
}