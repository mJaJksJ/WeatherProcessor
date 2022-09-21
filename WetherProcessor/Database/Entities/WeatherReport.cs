using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using WeatherProcessor.Database.Entities.Enums;

namespace WeatherProcessor.Database.Entities
{
    /// <summary>
    /// Запись о погоде
    /// </summary>
    public class WeatherReport
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Год
        /// </summary>
        [Range(0, 3000)]
        public int Year { get; set; }

        /// <summary>
        /// Месяц
        /// </summary>
        public Month Month { get; set; }

        /// <summary>
        /// Информация о погоде
        /// </summary>
        public List<WeatherReportInfo> WeatherReportInfo { get; set; }

        /// <summary>
        /// Настройки
        /// </summary>
        public static void Setup(ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<WeatherReport>();

            entity.ToTable("weather_report");
            entity.HasKey(t => t.Id);
        }
    }
}
