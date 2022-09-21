namespace WeatherProcessor.Models
{
    /// <summary>
    /// Модель пагинации
    /// </summary>
    public class PageInfoModel
    {
        /// <summary>
        /// Текущая страница
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Предыдущая страница
        /// </summary>
        public int Prev => PageNumber - 1 < 0 ? 0 : PageNumber - 1;

        /// <summary>
        /// Следующая страница
        /// </summary>
        public int Next => PageNumber + 1 > Last ? Last : PageNumber + 1;

        /// <summary>
        /// Первая страница
        /// </summary>
        public int First => 0;

        /// <summary>
        /// Последняя страница
        /// </summary>
        public int Last => TotalPages;

        /// <summary>
        /// Количество элементов на странице
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Количество элементов всего
        /// </summary>
        public int TotalItems { get; set; }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int TotalPages { get; set; }
    }
}
