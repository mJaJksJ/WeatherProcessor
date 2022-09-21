using Microsoft.EntityFrameworkCore;
using WeatherProcessor.Database.Entities;

namespace WeatherProcessor.Database
{
    /// <inheritdoc cref="DbContext"/>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        /// Запись о погоде
        /// </summary>
        public DbSet<WeatherReport> WeatherReports { get; set; }

        /// <summary>
        /// Информация о погоде
        /// </summary>
        public DbSet<WeatherReportInfo> WeatherReportInfos { get; set; }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            WeatherReport.Setup(modelBuilder);
            WeatherReportInfo.Setup(modelBuilder);
        }
    }
}
