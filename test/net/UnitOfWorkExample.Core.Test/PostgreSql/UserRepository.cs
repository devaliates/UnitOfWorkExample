namespace UnitOfWorkExample.Core.Test.PostgreSql;

public class UserRepository
    : EfRepositoryBase<User, Test1DbContext>
    , IUserRepository<Test1DbContext>
{
    public UserRepository(Test1DbContext context) : base(context)
    {
    }
}