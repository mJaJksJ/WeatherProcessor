using Microsoft.EntityFrameworkCore;
using WeatherProcessor.Database;
using WeatherProcessor.Database.Entities.Enums;
using WeatherProcessor.Models;

namespace WeatherProcessor.Services.ShowWeatherService
{
    /// <inheritdoc cref="IShowWeatherService"/>
    public class ShowWeatherService : IShowWeatherService
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="context"></param>
        public ShowWeatherService(DatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IEnumerable<WeatherModel> GetWeathers(int year, string month)
        {
            IEnumerable<WeatherModel> weathers = new List<WeatherModel>();
            var query = _context.WeatherReports
                .Include(_ => _.WeatherReportInfo)
                .ToArray();

            if (year != -1)
            {
                query = query.Where(_ => _.Year == year).ToArray();
            }

            if (month != "-1")
            {
                query = query.Where(_ => _.Month.RussianName() == month).ToArray();
            }

            var result = query
                .Select(_ => _.WeatherReportInfo.Select(w => new WeatherModel
                {
                    DateTime = w.DateTime,
                    Temperature = w.Temperature,
                    Humidity = w.Humidity,
                    DewPoint = w.DewPoint,
                    Pressure = w.Pressure,
                    WindDirections = w.WindDirections.Select(_ => _.RussianName()),
                    WindSpeed = w.WindSpeed,
                    CloudCover = w.CloudCover,
                    CloudLowerLimit = w.CloudLowerLimit,
                    HorizontalVisibility = w.HorizontalVisibility,
                    WeatherType = w.WeatherType,
                }))
                .AsEnumerable()
                .Aggregate(weathers, (current, w) => current.Union(w))
                .OrderBy(_ => _.DateTime);

            return result;
        }

        /// <inheritdoc/>
        public IEnumerable<int> GetYears()
        {
            return _context.WeatherReports.Select(_ => _.Year).Distinct().OrderBy(_ => _);
        }

        /// <inheritdoc/>
        public IEnumerable<string> GetMonths()
        {
            return Months.GetEnumerator().Select(_ => _.RussianName());
        }
    }
}
