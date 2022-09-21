namespace WeatherProcessor.Database.Entities.Enums
{
    /// <summary>
    /// Расширение для WeatherType
    /// </summary>
    public static class WeatherTypes
    {
        /// <summary>
        /// Попытать преобразовать к WindDirection
        /// </summary>
        /// <param name="s">Входное значение</param>
        /// <param name="result">Выходное значение</param>
        /// <returns></returns>
        public static bool TryParse(string s, out WeatherType? result)
        {
            result = s switch
            {
                "Дымка" => WeatherType.Hase,
                "Непрерывный слабый снег" => WeatherType.ContinuousLightSnow,
                "Снег" => WeatherType.Snow,
                "Ледяные иглы" => WeatherType.IceNeedles,
                "Ливневый снег" => WeatherType.RainfallSnow,
                "Непрерывный умеренный снег" => WeatherType.ContinuousMediumSnow,
                "Слабый ливневый снег" => WeatherType.LightRainfallSnow,
                "Слабый снег с перерывами" => WeatherType.LightSnowWithBreaks,
                _ => null
            };

            return result is not null;
        }
    }
}
