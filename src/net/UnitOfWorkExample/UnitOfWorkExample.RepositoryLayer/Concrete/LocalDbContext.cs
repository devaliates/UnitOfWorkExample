using Entities;

namespace UnitOfWorkExample.RepositoryLayer.Concrete;

public class LocalDbContext
    : DbContext, ILocalDbContext
{
    public DbSet<User> Users { get; set; }
}