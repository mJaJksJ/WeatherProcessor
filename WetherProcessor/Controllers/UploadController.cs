using Microsoft.AspNetCore.Mvc;
using WeatherProcessor.Models;
using WeatherProcessor.Services.ExcelFileService;

namespace WeatherProcessor.Controllers
{
    /// <summary>
    /// Контроллер страницы загрузки архивов погоды
    /// </summary>
    public class UploadController : Controller
    {
        private readonly IExcelFileService _excelFileService;

        /// <summary>
        /// .ctor
        /// </summary>
        public UploadController(IExcelFileService excelFileService)
        {
            _excelFileService = excelFileService;
        }

        /// <summary>
        /// Страница
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Получение файла
        /// </summary>
        /// <param name="file">Загружаемый файл</param>
        [HttpPost]
        public IActionResult Index(IFormFile file)
        {
            IEnumerable<string> errors;
            try
            {
                errors = _excelFileService.UploadToDb(file);
            }
            catch (Exception e)
            {
                errors = new List<string>() { e.Message };
            }

            return View(new UploadModel
            {
                FileName = file?.FileName,
                Errors = errors
            });
        }
    }
}
