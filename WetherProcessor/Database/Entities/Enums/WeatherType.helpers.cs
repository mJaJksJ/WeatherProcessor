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
                "Ливневый снег (ливневый дождь со снегом)" => WeatherType.RainfallWithSnow,
                "Непрерывный умеренный снег" => WeatherType.ContinuousMediumSnow,
                "Слабый ливневый снег" => WeatherType.LightRainfallSnow,
                "Слабый снег с перерывами" => WeatherType.LightSnowWithBreaks,
                "Состояние неба в целом не изменилось" => WeatherType.UnchangedState,
                "Облака в целом рассеивались или становились менее развитыми" => WeatherType.CloudLess,
                "Слабый позёмок" => WeatherType.LightPozemok,
                "Облака образовались или в целом развивались" => WeatherType.CloudForming,
                "Дождь" => WeatherType.Rain,
                "Ливневый дождь" => WeatherType.Rainfall,
                "Непрерывный слабый дождь" => WeatherType.ContinuousLightRain,
                "Отдаленная гроза" => WeatherType.RemoteThunderstorm,
                "Слабая морось, образующая гололед" => WeatherType.LightDrizzleWithIce,
                "Непрерывный сильный снег" => WeatherType.ContinuousHeavySnow,
                "Слабый дождь/морось со снегом" => WeatherType.DrizzleWithSnow,
                "Слабый ливневый дождь" => WeatherType.LightRainfall,
                "Гроза" => WeatherType.Thunderstorm,
                "Гроза с осадками" => WeatherType.ThunderWithFallout,
                "Гроза  с осадками" => WeatherType.ThunderWithFallout,
                "Непрерывный умеренный дождь" => WeatherType.ContinuousMediumRain,
                "Слабый дождь, образующий гололед" => WeatherType.LightRainWithIce,
                "Ливневый снег" => WeatherType.RainfallSnow,
                "Град (ледяная крупа)" => WeatherType.Hail,
                "Слабый дождь с перерывами" => WeatherType.LightRainWithBreaks,
                "Непрерывная слабая морось" => WeatherType.ContinuousLightDrizzle,
                "Туман начался/усиливался в последний час (неба не видно)" => WeatherType.FogFormingWithoutSky,
                "Ледяной дождь" => WeatherType.IceRain,
                "Морось (дождь) с образованием гололеда" => WeatherType.DrizzleWithIce,
                "Умеренный дождь с перерывами" => WeatherType.MediumRainWithBreaks,
                "Отдельные снежные кристаллы" => WeatherType.IndividualSnowCrystals,
                "Слабая ледяная/снежная крупа" => WeatherType.LightIceSnowGrains,
                "Слабый ливневый дождь со снегом" => WeatherType.LightRainfallWithSnow,
                "Слабый дождь (гроза в течение последнего часа)" => WeatherType.LightRainWithThunderstorm,
                "Туман начался/усиливался в последний час (небо видно)" => WeatherType.ForFormingWithSky,
                "Непрерывный сильный дождь" => WeatherType.ContinuousHeavyRain,
                "Морось" => WeatherType.Drizzle,
                "Снежные зерна" => WeatherType.SnowGrains,
                "Слабая морось с дождем" => WeatherType.LightDrizzleWithRain,
                "Туман без изменения интенсивности в последний час (неба не видно)" => WeatherType.FogContinuousWithoutSky,
                "Дождь (гроза в течение последнего часа)" => WeatherType.RainWithThinderstorm,
                "Очень сильный ливневый дождь" => WeatherType.VeryHeavyRainfall,
                "Ледяная крупа" => WeatherType.IceGrains,
                "Непрерывная умеренная морось" => WeatherType.ContinuousMediumDrizzle,
                "Туман" => WeatherType.Fog,
                "Туман без изменения интенсивности в последний час (небо видно)" => WeatherType.FogContinuousWithSky,
                "Сильный снег с перерывами" => WeatherType.HeavySnowWithBreaks,
                "Сильный дождь/морось со снегом" => WeatherType.HeavyRainDrizzleWithShow,
                "" => WeatherType.None,
                _ => null
            };

            return result is not null;
        }
    }
}
