using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WeatherProcessor.Database.Entities.Enums;

namespace WeatherProcessor.Database.Entities
{
    /// <summary>
    /// Информация о погоде
    /// </summary>
    public class WeatherReportInfo
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата и время записи
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// Температура °C
        /// </summary>
        public int Temperature { get; set; }

        /// <summary>
        /// Влажность %
        /// </summary>
        [Range(0, 100)]
        public int Humidity { get; set; }

        /// <summary>
        /// Точка росы
        /// </summary>
        public int Dewpoint { get; set; }

        /// <summary>
        /// Давление мм.р.т.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Pressure { get; set; }

        /// <summary>
        /// Направление ветра
        /// </summary>
        public WindDirection WindDirection { get; set; }

        /// <summary>
        /// Скорость ветра
        /// </summary>
        [Range(0, int.MaxValue)]
        public int WindSpeed { get; set; }

        /// <summary>
        /// Облачность
        /// </summary>
        [Range(0, 100)]
        public int CloudCover { get; set; }

        /// <summary>
        /// Нижняя граница облачности
        /// </summary>
        [Range(0, int.MaxValue)]
        public int CloudLowerLimit { get; set; }

        /// <summary>
        /// Горизонтальная видимость
        /// </summary>
        [Range(0, int.MaxValue)]
        public int HorizontalVisibility { get; set; }

        /// <summary>
        /// Погодные явления
        /// </summary>
        public WeatherTypes WeatherTypes { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<WeatherReportInfo>();

            entity.ToTable("weather_report_info");
            entity.HasKey(t => t.Id);
        }
    }
}
