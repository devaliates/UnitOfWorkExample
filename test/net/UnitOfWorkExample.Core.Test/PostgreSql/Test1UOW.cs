namespace UnitOfWorkExample.Core.Test.PostgreSql;

public class Test1UOW
    : UnitOfWorkBase<Test1DbContext>
    , IUnitOfWork
{
    public IUserRepository UserRepository
    {
        get
        {
            if (userRepository == null)
                this.userRepository = new UserRepository(base.context);
            return this.userRepository;
        }
    }
    private IUserRepository userRepository;

    public Test1UOW(Test1DbContext context) : base(context)
    {
        this.userRepository = new UserRepository(context);
        this.context = context;
    }
}