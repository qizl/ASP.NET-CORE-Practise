namespace RazorPagesMovie.Models
{
    public interface IFruitService
    {
        string GetName();
    }

    public class AppleService : IFruitService
    {
        public string GetName() => "i'm an apple!";
    }
}
