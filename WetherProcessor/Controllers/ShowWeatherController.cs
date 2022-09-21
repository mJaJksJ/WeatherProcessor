using Microsoft.AspNetCore.Mvc;
using WeatherProcessor.Models;
using WeatherProcessor.Services.ShowWeatherService;

namespace WeatherProcessor.Controllers
{
    /// <summary>
    /// Контроллер страницы просмотра погоды
    /// </summary>
    public class ShowWeatherController : Controller
    {
        private readonly IShowWeatherService _showWeatherService;

        /// <summary>
        /// .ctor
        /// </summary>
        public ShowWeatherController(IShowWeatherService showWeatherService)
        {
            _showWeatherService = showWeatherService;
        }

        /// <summary>
        /// Страница
        /// </summary>
        public IActionResult Index(IEnumerable<int> years, IEnumerable<string> months, int pageNumber = 0)
        {
            var weathers = _showWeatherService.GetWeathers(years, months);
            var result = new ShowWeatherModel
            {
                Weathers = weathers
                    .Skip(PageInfoModel.PageSize * pageNumber)
                    .Take(PageInfoModel.PageSize),
                PageInfo = new PageInfoModel
                {
                    TotalItems = weathers.Count(),
                    PageNumber = pageNumber,
                    TotalPages = (int)Math.Ceiling((decimal)weathers.Count() / PageInfoModel.PageSize) - 1
                },
                YearsFilter = years,
                MonthsFilter = months
            };

            return View(result);
        }
    }
}
