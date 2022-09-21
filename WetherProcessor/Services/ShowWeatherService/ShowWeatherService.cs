using Microsoft.EntityFrameworkCore;
using WeatherProcessor.Database;
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
        public IEnumerable<WeatherModel> GetWeathers(IEnumerable<int> years, IEnumerable<string> months)
        {
            IEnumerable<WeatherModel> weathers = new List<WeatherModel>();
            var result = _context.WeatherReports
                .Include(_ => _.WeatherReportInfo)
                .Select(_ => _.WeatherReportInfo.Select(w => new WeatherModel
                {
                    DateTime = w.DateTime,
                    Temperature = w.Temperature,
                    Humidity = w.Humidity,
                    DewPoint = w.DewPoint,
                    Pressure = w.Pressure,
                    WindDirections = w.WindDirections,
                    WindSpeed = w.WindSpeed,
                    CloudCover = w.CloudCover,
                    CloudLowerLimit = w.CloudLowerLimit,
                    HorizontalVisibility = w.HorizontalVisibility,
                    WeatherType = w.WeatherType,
                }))
                .AsEnumerable()
                .Aggregate(weathers, (current, w) => current.Union(w));

            return result;
        }
    }
}
