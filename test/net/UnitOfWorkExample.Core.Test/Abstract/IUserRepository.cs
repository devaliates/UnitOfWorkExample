namespace UnitOfWorkExample.Core.Test.Abstract;

public interface IUserRepository<TDbContext>
    : IRepositoryBase<User, TDbContext>
{
}