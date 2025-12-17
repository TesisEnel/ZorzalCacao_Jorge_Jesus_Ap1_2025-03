using Microsoft.EntityFrameworkCore;
using ZorzalCacao.Data;

namespace ZorzalCacao.Tests;

internal class DbContextFactoryMock : IDbContextFactory<ApplicationDbContext>
{
    private readonly DbContextOptions<ApplicationDbContext> _options;

    public DbContextFactoryMock(string dbName)
    {
        _options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;
    }

    public ApplicationDbContext CreateDbContext()
        => new ApplicationDbContext(_options);

    public ValueTask<ApplicationDbContext> CreateDbContextAsync(
        CancellationToken cancellationToken = default)
        => new ValueTask<ApplicationDbContext>(CreateDbContext());
}
