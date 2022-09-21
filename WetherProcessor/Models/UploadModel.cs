namespace WeatherProcessor.Models
{
    /// <summary>
    /// Модель представления Upload
    /// </summary>
    public class UploadModel
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Ошибки
        /// </summary>
        public IEnumerable<string> Errors { get; set; }
    }
}
