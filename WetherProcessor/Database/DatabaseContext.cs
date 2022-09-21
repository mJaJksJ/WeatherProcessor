using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql;
using Npgsql.NameTranslation;
using WeatherProcessor.Database.Entities;
using WeatherProcessor.Database.Entities.Enums;

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

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="options"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        /// <inheritdoc/>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<Month>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<WeatherTypes>();
            NpgsqlConnection.GlobalTypeMapper.MapEnum<WindDirection>();
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<Month>();
            modelBuilder.HasPostgresEnum<WeatherTypes>();
            modelBuilder.HasPostgresEnum<WindDirection>();

            var mapper = new NpgsqlSnakeCaseNameTranslator();
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var storeObjectIdentifier = StoreObjectIdentifier.Table(entity.GetTableName(), entity.GetSchema());
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(mapper.TranslateMemberName(property.GetColumnName(storeObjectIdentifier) ?? string.Empty));
                }
            }

            WeatherReport.Setup(modelBuilder);
            WeatherReportInfo.Setup(modelBuilder);
        }
    }
}
