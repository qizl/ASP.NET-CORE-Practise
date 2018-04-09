using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;

namespace RazorPagesMovie.Pages.DI
{
    public class FruitModel : PageModel
    {
        private readonly IFruitService _service;

        public FruitModel(IFruitService service)
        {
            this._service = service;
        }

        public IActionResult OnGet()
        {
            ViewData["Name"] = this._service.GetName();
            ViewData["MovieName"] = this._service.GetAMovie();

            return Page();
        }
    }
}