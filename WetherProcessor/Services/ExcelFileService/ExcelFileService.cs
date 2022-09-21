using System.ComponentModel;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WeatherProcessor.Database;
using WeatherProcessor.Database.Entities;
using WeatherProcessor.Database.Entities.Enums;
using WeatherProcessor.Exceptions;

namespace WeatherProcessor.Services.ExcelFileService
{
    /// <inheritdoc cref="IExcelFileService"/>
    public class ExcelFileService : IExcelFileService
    {
        private readonly string[] _excelExtensions = { ".xls", ".xlsx" };
        private const int StartRow = 4;

        #region columnIds

        private const int DateIdx = 0;
        private const int TimeIdx = 1;
        private const int TemperatureIdx = 2;
        private const int HumidityIdx = 3;
        private const int DewpointIdx = 4;
        private const int PressureIdx = 5;
        private const int WindDirectionIdx = 6;
        private const int WindSpeedIdx = 7;
        private const int CloudCoverIdx = 8;
        private const int CloudLowerLimitIdx = 9;
        private const int HorizontalVisibilityIdx = 10;
        private const int WeatherTypesIdx = 11;

        #endregion columnIds

        private readonly List<string> _errors = new();

        private readonly DatabaseContext _context;

        private static readonly Serilog.ILogger Log = Serilog.Log.ForContext<ExcelFileService>();

        /// <summary>
        /// .ctor
        /// </summary>
        public ExcelFileService(DatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public IEnumerable<string> UploadToDb(IFormFile file)
        {
            try
            {
                EnsureExcelFile(file);
            }
            catch (NotExcelFileException exception)
            {
                Log.Error(exception.Message, exception);
                return new[] { exception.Message };
            }

            var e = int.TryParse(file.FileName.Split(new[] { '_', '.' }, StringSplitOptions.RemoveEmptyEntries)[^2], out var year);
            if (!e)
            {
                var errMsg = $"Invalid file name {file.FileName}";
                Log.Error(errMsg);
                return new[] { errMsg };
            }

            var weatherReports = new List<WeatherReport>();
            foreach (var month in Months.GetEnumerator())
            {
                string sheetName;
                try
                {
                    sheetName = $"{month.RussianName()} {year}";
                }
                catch (InvalidEnumArgumentException exception)
                {
                    Log.Error(exception.Message, exception);
                    return new[] { exception.Message };
                }

                var sheet = InitSheet(file, sheetName);

                var weatherReport = new WeatherReport
                {
                    Month = month,
                    Year = year,
                    WeatherReportInfo = new List<WeatherReportInfo>()
                };

                for (var i = StartRow; i <= sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);
                    var info = ParseRow(row, i);
                    if (info is not null)
                    {
                        weatherReport.WeatherReportInfo.Add(info);
                    }
                }

                if (!_errors.Any())
                {
                    weatherReports.Add(weatherReport);
                }
            }

            if (_errors.Any())
            {
                return _errors;
            }

            _context.AddRange(weatherReports);
            _context.SaveChanges();
            return Array.Empty<string>();
        }

        /// <inheritdoc/>
        public void EnsureExcelFile(IFormFile file)
        {
            if (!_excelExtensions.Contains(Path.GetExtension(file?.FileName ?? ".").ToLower()))
            {
                throw new NotExcelFileException(file?.FileName ?? "");
            }
        }

        private void AddError(object val, string variable)
        {
            _errors.Add($"Can't convert {val} to {variable}");
        }

        private WeatherReportInfo ParseRow(IRow row, int rowIdx)
        {
            var errorsCount = _errors.Count;

            if (row == null || row.Cells.All(d => d.CellType == CellType.Blank))
            {
                _errors.Add($"bad line #{rowIdx}");
                return null;
            }

            var data = $"{row.GetCell(DateIdx)} {row.GetCell(TimeIdx)}";
            var e = DateTime.TryParse(data, out var dateTime);
            if (!e)
            {
                AddError(data, "DateTime");
            }

            data = row.GetCell(TemperatureIdx)?.ToString();
            data = string.IsNullOrWhiteSpace(data) ? "0" : data;
            e = double.TryParse(data, out var temperature);
            if (!e)
            {
                AddError(data, "Temperature");
            }

            data = row.GetCell(HumidityIdx)?.ToString();
            data = string.IsNullOrWhiteSpace(data) ? "0" : data;
            e = double.TryParse(data, out var humidity);
            if (!e)
            {
                AddError(data, "Humidity");
            }

            data = row.GetCell(DewpointIdx)?.ToString();
            data = string.IsNullOrWhiteSpace(data) ? "0" : data;
            e = double.TryParse(data, out var dewPoint);
            if (!e)
            {
                AddError(data, "DewPoint");
            }

            data = row.GetCell(PressureIdx)?.ToString();
            data = string.IsNullOrWhiteSpace(data) ? "0" : data;
            e = int.TryParse(data, out var pressure);
            if (!e)
            {
                AddError(data, "Pressure");
            }

            var wds = row.GetCell(WindDirectionIdx)?.ToString().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var windDirections = new List<WindDirection>();
            foreach (var wd in wds)
            {
                e = WindDirections.TryParse(string.IsNullOrWhiteSpace(wd) ? "" : wd, out var windDirection);
                if (!e)
                {
                    AddError(wd, "WindDirection");
                }
                else
                {
                    windDirections.Add(windDirection ?? default);
                }
            }

            data = row.GetCell(WindSpeedIdx)?.ToString();
            data = string.IsNullOrWhiteSpace(data) ? "0" : data;
            e = int.TryParse(data, out var windSpeed);
            if (!e)
            {
                AddError(data, "WindSpeed");
            }

            data = row.GetCell(CloudCoverIdx)?.ToString();
            data = string.IsNullOrWhiteSpace(data) ? "0" : data;
            e = int.TryParse(data, out var cloudCover);
            if (!e)
            {
                AddError(data, "CloudCover");
            }

            data = row.GetCell(CloudLowerLimitIdx)?.ToString();
            data = string.IsNullOrWhiteSpace(data) ? "0" : data;
            e = int.TryParse(data, out var cloudLowerLimit);
            if (!e)
            {
                AddError(data, "CloudLowerLimit");
            }

            data = row.GetCell(HorizontalVisibilityIdx)?.ToString();
            data = string.IsNullOrWhiteSpace(data) ? "0" : data == "менее 100 м" ? "-100" : data;
            e = double.TryParse(data, out var horizontalVisibility);
            if (!e)
            {
                AddError(data, "HorizontalVisibility");
            }

            data = row.GetCell(WeatherTypesIdx)?.ToString();
            data = string.IsNullOrWhiteSpace(data) ? "" : data;
            e = WeatherTypes.TryParse(data, out var weatherType);
            if (!e)
            {
                AddError(data, "WeatherTypes");
            }

            // если количество ошибок не увеличилось то возвращаем объект
            if (errorsCount == _errors.Count)
            {
                return new WeatherReportInfo
                {
                    DateTime = dateTime,
                    Temperature = temperature,
                    Humidity = humidity,
                    DewPoint = dewPoint,
                    Pressure = pressure,
                    WindDirections = windDirections.ToArray(),
                    WindSpeed = windSpeed,
                    CloudCover = cloudCover,
                    CloudLowerLimit = cloudLowerLimit,
                    HorizontalVisibility = horizontalVisibility,
                    WeatherType = weatherType ?? default,
                };
            }
            else
            {
                return null;
            }
        }

        private static ISheet InitSheet(IFormFile file, string sheetName)
        {
            var extension = Path.GetExtension(file.FileName).ToLower();

            if (extension.ToLower() == ".xls")
            {
                HSSFWorkbook hssfwb;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    ms.Position = 0;
                    hssfwb = new HSSFWorkbook(ms);
                }

                return hssfwb.GetSheet(sheetName);
            }
            else
            {
                XSSFWorkbook xssfwb;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    ms.Position = 0;
                    xssfwb = new XSSFWorkbook(ms);
                }

                return xssfwb.GetSheet(sheetName);
            }
        }
    }
}
