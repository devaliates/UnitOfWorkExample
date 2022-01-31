using Entities;

namespace UnitOfWorkExample.RepositoryLayer.Concrete;

public class AzureDbContext
    : DbContext, IAzureDbContext
{
    public DbSet<User> Users { get; set; }
}