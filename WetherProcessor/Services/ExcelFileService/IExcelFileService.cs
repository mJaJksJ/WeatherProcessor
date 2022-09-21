namespace WeatherProcessor.Services.ExcelFileService
{
    /// <summary>
    /// Сервис работы с эксель файлами
    /// </summary>
    public interface IExcelFileService
    {
        /// <summary>
        /// Загрузить файл в БД <br/>
        /// <i>Прим.: проверка на эксель-файл встроена в метод</i>
        /// </summary>
        /// <param name="file">Файл</param>
        /// <exception cref="InvalidEnumArgumentException">Если не реализовано для данного элемента month</exception>
        /// <returns>Список ошибок</returns>
        IEnumerable<string> UploadToDb(IFormFile file);

        /// <summary>
        /// Убедиться что файл - эксель
        /// </summary>
        /// <param name="file">Файл</param>
        /// <exception cref="NotExcelFileException">Если файл не эксель</exception>
        public void EnsureExcelFile(IFormFile file);
    }
}
