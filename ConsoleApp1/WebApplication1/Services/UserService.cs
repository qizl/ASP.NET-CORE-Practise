namespace WebApplication1.Services
{
    public interface IUserService
    {
        string SayHello();
    }

    public class UserService : IUserService
    {
        public string SayHello() => "Hello, NET Core!";
    } 
}
