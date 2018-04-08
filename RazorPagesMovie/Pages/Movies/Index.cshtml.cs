using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovie.Models.MovieContext _context;

        public IndexModel(RazorPagesMovie.Models.MovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get; set; }
        public string CurrentSearchString { get; set; }
        public SelectList Genres { get; set; }
        public string CurrentGenre { get; set; }

        public async Task OnGetAsync(string searchString, string movieGenre)
        {
            //Movie = await _context.Movie.ToListAsync();
            this.CurrentSearchString = searchString;
            this.CurrentGenre = movieGenre;

            var movies = from m in this._context.Movie select m;
            var genres = from m in this._context.Movie orderby m.Genre select m.Genre;

            if (!string.IsNullOrEmpty(searchString))
                movies = movies.Where(m => m.Title.Contains(searchString));
            if (!string.IsNullOrEmpty(movieGenre))
                movies = movies.Where(m => m.Genre == movieGenre);

            Genres = new SelectList(await genres.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }
    }
}
