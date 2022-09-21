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
        /// Запись о погоде
        /// </summary>
        public WeatherReport WeatherReport { get; set; }

        /// <summary>
        /// Id записи о погоде
        /// </summary>
        public int WeatherReportId { get; set; }

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
        [Range(0, 100)]
        public double Humidity { get; set; }

        /// <summary>
        /// Точка росы
        /// </summary>
        public double DewPoint { get; set; }

        /// <summary>
        /// Давление мм.р.т.
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Pressure { get; set; }

        /// <summary>
        /// Направление ветра
        /// </summary>
        public WindDirection[] WindDirections { get; set; }

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
        public double HorizontalVisibility { get; set; }

        /// <summary>
        /// Погодные явления
        /// </summary>
        public WeatherType WeatherType { get; set; }

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
