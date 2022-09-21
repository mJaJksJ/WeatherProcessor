namespace WeatherProcessor.Models
{
    public class ShowWeatherModel
    {
        /// <summary>
        /// Записи о погоде
        /// </summary>
        public IEnumerable<WeatherModel> Weathers { get; set; }

        /// <summary>
        /// Пагинация
        /// </summary>
        public PageInfoModel PageInfo { get; set; }

        /// <summary>
        /// Фильтр по годам
        /// </summary>
        public IEnumerable<int> YearsFilter { get; set; }

        /// <summary>
        /// Фильтр по месяцам
        /// </summary>
        public IEnumerable<string> MonthsFilter { get; set; }

        /// <summary>
        /// Выбранный год
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Выбранный месяц
        /// </summary>
        public string Month { get; set; }
    }
}
