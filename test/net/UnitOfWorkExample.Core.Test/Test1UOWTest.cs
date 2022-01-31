namespace UnitOfWorkExample.Core.Test;

public class Test1UOWTest
{
    private Test1UOW test1UOW;

    [OneTimeSetUp]
    public void Setup()
    {
        this.test1UOW = new Test1UOW(new Test1DbContext());
    }

    [Test]
    public void ADD_USER()
    {
        //User user = new User()
        //{
        //    Username = "Ali",
        //    Password = "Ateş",
        //};

        //var r = this.test1UOW.BeginTransactionAsync().Result;

        //this.test1UOW.UserRepository.Insert(user).Wait();

        //this.test1UOW.Save().Wait();

        //Assert.NotZero(user.Id);
    }
}