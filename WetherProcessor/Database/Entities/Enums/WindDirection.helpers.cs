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
                "З" => WindDirection.SouthWest,
                "СЗ" => WindDirection.NorthWest,
                _ => null
            };

            return result is not null;
        }
    }
}
