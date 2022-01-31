namespace UnitOfWorkExample.RepositoryLayer.Concrete;

public class LocalDbContext
    : DbContext, ILocalDbContext
{
    public DbSet<User> Users { get; set; }

    public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
    {
    }
}