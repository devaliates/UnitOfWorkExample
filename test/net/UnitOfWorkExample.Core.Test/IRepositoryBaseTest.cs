namespace UnitOfWorkExample.Core.Test;

public class IRepositoryBaseTest
{
    [OneTimeSetUp]
    public void Setup()
    {
    }

    [Test]
    public void ADD_USER()
    {
        User user = new User()
        {
            Username = "Ali",
            Password = "Ateş",
        };

        Assert.NotZero(user.Id);
    }
}