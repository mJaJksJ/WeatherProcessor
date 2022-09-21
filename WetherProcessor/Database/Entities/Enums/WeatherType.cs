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
        /// Ливневый снег (ливневый дождь со снегом)
        /// </summary>
        RainfallWithSnow,

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

        /// <summary>
        /// "Состояние неба в целом не изменилось
        /// </summary>
        UnchangedState,

        /// <summary>
        /// Облака в целом рассеивались или становились менее развитыми
        /// </summary>
        CloudLess,

        /// <summary>
        /// Слабый позёмок
        /// </summary>
        LightPozemok,

        /// <summary>
        /// Облака образовались или в целом развивались
        /// </summary>
        CloudForming,

        /// <summary>
        /// Дождь
        /// </summary>
        Rain,

        /// <summary>
        /// Ливневый дождь
        /// </summary>
        Rainfall,

        /// <summary>
        /// Непрерывный слабый дождь
        /// </summary>
        ContinuousLightRain,

        /// <summary>
        /// Отдаленная гроза
        /// </summary>
        RemoteThunderstorm,

        /// <summary>
        /// Слабая морось, образующая гололед
        /// </summary>
        LightDrizzleWithIce,

        /// <summary>
        /// Непрерывный сильный снег
        /// </summary>
        ContinuousHeavySnow,

        /// <summary>
        /// Непрерывный сильный снег
        /// </summary>
        DrizzleWithSnow,

        /// <summary>
        /// Слабый дождь/морось со снегом
        /// </summary>
        LightRainfall,

        /// <summary>
        /// Гроза
        /// </summary>
        Thunderstorm,

        /// <summary>
        /// Гроза с осадками
        /// </summary>
        ThunderWithFallout,

        /// <summary>
        /// Непрерывный умеренный дождь
        /// </summary>
        ContinuousMediumRain,

        /// <summary>
        /// Слабый дождь, образующий гололед
        /// </summary>
        LightRainWithIce,

        /// <summary>
        /// Ливневый снег
        /// </summary>
        RainfallSnow,

        /// <summary>
        /// Град (ледяная крупа)
        /// </summary>
        Hail,

        /// <summary>
        /// Слабый дождь с перерывами
        /// </summary>
        LightRainWithBreaks,

        /// <summary>
        /// Непрерывная слабая морось
        /// </summary>
        ContinuousLightDrizzle,

        /// <summary>
        /// Туман начался/усиливался в последний
        /// </summary>
        FogFormingWithoutSky,

        /// <summary>
        /// Ледяной дождь
        /// </summary>
        IceRain,

        /// <summary>
        /// Морось (дождь) с образованием гололеда
        /// </summary>
        DrizzleWithIce,

        /// <summary>
        /// Умеренный дождь с перерывами
        /// </summary>
        MediumRainWithBreaks,

        /// <summary>
        /// Отдельные снежные кристаллы
        /// </summary>
        IndividualSnowCrystals,

        /// <summary>
        /// Слабая ледяная/снежная крупа
        /// </summary>
        LightIceSnowGrains,

        /// <summary>
        /// Слабый ливневый дождь со снегом
        /// </summary>
        LightRainfallWithSnow,

        /// <summary>
        /// Слабый дождь (гроза в течение последнего часа)
        /// </summary>
        LightRainWithThunderstorm,

        /// <summary>
        /// Туман начался/усиливался в последний час (небо видно)
        /// </summary>
        ForFormingWithSky,

        /// <summary>
        /// Непрерывный сильный дождь
        /// </summary>
        ContinuousHeavyRain,

        /// <summary>
        /// Морось
        /// </summary>
        Drizzle,

        /// <summary>
        /// Снежные зерна
        /// </summary>
        SnowGrains,

        /// <summary>
        /// Слабая морось с дождем
        /// </summary>
        LightDrizzleWithRain,

        /// <summary>
        /// Туман без изменения интенсивности в последний час (неба не видно)
        /// </summary>
        FogContinuousWithoutSky,

        /// <summary>
        /// Дождь (гроза в течение последнего часа)
        /// </summary>
        RainWithThinderstorm,

        /// <summary>
        /// Очень сильный ливневый дождь
        /// </summary>
        VeryHeavyRainfall,

        /// <summary>
        /// Ледяная крупа
        /// </summary>
        IceGrains,

        /// <summary>
        /// Непрерывная умеренная морось
        /// </summary>
        ContinuousMediumDrizzle,

        /// <summary>
        /// Туман
        /// </summary>
        Fog,

        /// <summary>
        /// Туман без изменения интенсивности в последний час (небо видно)
        /// </summary>
        FogContinuousWithSky,

        /// <summary>
        /// Сильный снег с перерывами
        /// </summary>
        HeavySnowWithBreaks,

        /// <summary>
        /// Сильный дождь/морось со снегом
        /// </summary>
        HeavyRainDrizzleWithShow,

        /// <summary>
        /// Погодные явления отсутствуют
        /// </summary>
        None = -1
    }
}
