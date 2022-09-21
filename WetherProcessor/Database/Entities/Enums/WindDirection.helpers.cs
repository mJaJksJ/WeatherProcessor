using System.ComponentModel;

namespace WeatherProcessor.Database.Entities.Enums
{
    /// <summary>
    /// Расширение для WindDirection
    /// </summary>
    public static class WindDirections
    {
        /// <summary>
        /// Попытать преобразовать к WindDirection
        /// </summary>
        /// <param name="s">Входное значение</param>
        /// <param name="result">Выходное значение</param>
        /// <returns></returns>
        public static bool TryParse(string s, out WindDirection? result)
        {
            result = s switch
            {
                "С" => WindDirection.North,
                "СВ" => WindDirection.NorthEast,
                "В" => WindDirection.East,
                "ЮВ" => WindDirection.SouthEast,
                "Ю" => WindDirection.South,
                "ЮЗ" => WindDirection.SouthWest,
                "З" => WindDirection.West,
                "СЗ" => WindDirection.NorthWest,
                "штиль" => WindDirection.Calm,
                "" => WindDirection.Calm,
                _ => null
            };

            return result is not null;
        }

        /// <summary>
        /// Получить русское название
        /// </summary>
        /// <param name="windDirection">Направление ветра</param>
        /// <exception cref="InvalidEnumArgumentException">Если не реализовано для данного элемента month</exception>
        public static string RussianName(this WindDirection windDirection)
        {
            return windDirection switch
            {
                WindDirection.North => "С",
                WindDirection.NorthEast => "СВ",
                WindDirection.East => "В",
                WindDirection.SouthEast => "ЮВ",
                WindDirection.South => "Ю",
                WindDirection.SouthWest => "ЮЗ",
                WindDirection.West => "З",
                WindDirection.NorthWest => "СЗ",
                WindDirection.Calm => "штиль",
                _ => throw new InvalidEnumArgumentException(windDirection.ToString()),
            };
        }
    }
}
