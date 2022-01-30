using Microsoft.EntityFrameworkCore;

using UnitOfWorkExample.Core.Test.Entities;

namespace UnitOfWorkExample.Core.Test.PostgreSql;

public class Test1DbContext
    : DbContext
{
    public DbSet<User> Users { get; set; }

    private const string connectionString = "User ID=ali; Password=ali*ates; Server=localhost; Port=5432; Database=UnitOfWorkTestDB; Integrated Security=true; Pooling=true;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(connectionString);
    }
}