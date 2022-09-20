using Microsoft.AspNetCore.Mvc;

namespace WeatherProcessor.Controllers
{
    /// <summary>
    /// Контроллер страницы загрузки архивов погоды
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
