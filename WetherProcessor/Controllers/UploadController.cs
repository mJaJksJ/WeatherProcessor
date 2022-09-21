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
        /// <param name="files">Загружаемый файл</param>
        [HttpPost]
        public IActionResult Index(IFormFileCollection files)
        {
            foreach (var file in files)
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

                if (errors.Any())
                {
                    return View(new UploadModel
                    {
                        FileName = file?.FileName,
                        Errors = errors
                    });
                }
            }

            return View(new UploadModel
            {
                FileName = string.Join(", ", files.Select(_ => _.FileName)),
                Errors = Array.Empty<string>()
            });
        }
    }
}
