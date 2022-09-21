namespace WeatherProcessor.Database.Entities.Enums
{
    /// <summary>
    /// Погодные явления
    /// </summary>
    public enum WeatherType
    {
        /// <summary>
        /// Дымка
        /// </summary>
        Hase,

        /// <summary>
        /// Непрерывный слабый снег
        /// </summary>
        ContinuousLightSnow,

        /// <summary>
        /// Снег
        /// </summary>
        Snow,

        /// <summary>
        /// Ледяные иглы
        /// </summary>
        IceNeedles,

        /// <summary>
        /// Ливневый снег
        /// </summary>
        RainfallSnow,

        /// <summary>
        /// Непрерывный умеренный снег
        /// </summary>
        ContinuousMediumSnow,

        /// <summary>
        /// Слабый ливневый снег
        /// </summary>
        LightRainfallSnow,

        /// <summary>
        /// Слабый снег с перерывами
        /// </summary>
        LightSnowWithBreaks,
    }
}
