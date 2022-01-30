using UnitOfWorkExample.Core.Abstract;
using UnitOfWorkExample.Core.Concrete;
using UnitOfWorkExample.Core.Test.Abstract;

namespace UnitOfWorkExample.Core.Test.PostgreSql;

public class Test1UOW
    : UnitOfWorkBase<Test1DbContext>
    , IUnitOfWork
{
    private IUserRepository userRepository;
    public IUserRepository UserRepository
    {
        get
        {
            if (userRepository == null)
                this.userRepository = new UserRepository(base.context);
            return this.userRepository;
        }
    }

    public Test1UOW(Test1DbContext context) : base(context)
    {
        this.userRepository = new UserRepository(context);
        this.context = context;
    }
}
