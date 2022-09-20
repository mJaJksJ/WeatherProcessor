using Microsoft.AspNetCore.Mvc;

namespace WeatherProcessor.Controllers
{
    /// <summary>
    /// Контроллер страницы згрузки архивов погоды
    /// </summary>
    public class UploadController : Controller
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
