using Microsoft.AspNetCore.Mvc;

namespace WeatherProcessor.Controllers
{
    /// <summary>
    /// Контроллер страницы просмотра погоды
    /// </summary>
    public class ShowWeatherController : Controller
    {
        /// <summary>
        /// Страница
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }
    }
}
