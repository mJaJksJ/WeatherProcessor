using Microsoft.AspNetCore.Mvc;

namespace WeatherProcessor.Controllers
{
    /// <summary>
    /// Контроллер главной страницы
    /// </summary>
    public class MainPageController : Controller
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
