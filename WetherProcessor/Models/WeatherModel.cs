using WeatherProcessor.Database.Entities.Enums;

namespace WeatherProcessor.Models
{
    /// <summary>
    /// Модель записи о погоде
    /// </summary>
    public class WeatherModel
    {
        /// <summary>
        /// Дата и время записи
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Температура °C
        /// </summary>
        public double Temperature { get; set; }

        /// <summary>
        /// Влажность %
        /// </summary>
        public double Humidity { get; set; }

        /// <summary>
        /// Точка росы
        /// </summary>
        public double DewPoint { get; set; }

        /// <summary>
        /// Давление мм.р.т.
        /// </summary>
        public int Pressure { get; set; }

        /// <summary>
        /// Направление ветра
        /// </summary>
        public WindDirection[] WindDirections { get; set; }

        /// <summary>
        /// Скорость ветра
        /// </summary>
        public int WindSpeed { get; set; }

        /// <summary>
        /// Облачность
        /// </summary>
        public int CloudCover { get; set; }

        /// <summary>
        /// Нижняя граница облачности
        /// </summary>
        public int CloudLowerLimit { get; set; }

        /// <summary>
        /// Горизонтальная видимость
        /// </summary>
        public double HorizontalVisibility { get; set; }

        /// <summary>
        /// Погодные явления
        /// </summary>
        public WeatherType WeatherType { get; set; }
    }
}
