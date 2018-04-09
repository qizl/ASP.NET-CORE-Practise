using System.Linq;

namespace RazorPagesMovie.Models
{
    public interface IFruitService
    {
        string GetName();
        string GetAMovie();
    }

    public class AppleService : IFruitService
    {
        private readonly MovieContext _dbContext;

        public AppleService(MovieContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public string GetAMovie() => this._dbContext?.Movie.OrderBy(m => m.ReleaseDate).First().Title;

        public string GetName() => "i'm an apple!";
    }
}
