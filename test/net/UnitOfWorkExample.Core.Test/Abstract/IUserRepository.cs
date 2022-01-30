using UnitOfWorkExample.Core.Abstract;
using UnitOfWorkExample.Core.Test.Entities;

namespace UnitOfWorkExample.Core.Test.Abstract;

public interface IUserRepository
    : IRepositoryBase<User>
{
}
