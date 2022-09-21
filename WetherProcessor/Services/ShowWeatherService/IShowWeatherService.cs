using WeatherProcessor.Models;

namespace WeatherProcessor.Services.ShowWeatherService
{
    /// <summary>
    /// Сервис работы с записями о погоде
    /// </summary>
    public interface IShowWeatherService
    {
        /// <summary>
        /// Получить записи о погоде
        /// </summary>
        /// <param name="years">Фильтр по годам</param>
        /// <param name="months">Фильтр по месяцам</param>
        IEnumerable<WeatherModel> GetWeathers(IEnumerable<int> years, IEnumerable<string> months);
    }
}
