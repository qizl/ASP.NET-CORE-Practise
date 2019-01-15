using Microsoft.AspNetCore.Mvc;

namespace MvcCore.ViewComponents
{
    public class CitySummary : ViewComponent
    {
        public CitySummary() { }

        public string Invoke(int cityCount, int peopleCount) => $"{cityCount} cities, {peopleCount} people";
    }
}
