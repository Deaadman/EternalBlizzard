using EternalWeather.Properties;

namespace EternalWeather;

internal static class SetWeatherStage
{
    internal static void WeatherStageChange()
    {
        var selectedWeather = Settings.Instance.ChooseWeatherStage;

        if (selectedWeather == WeatherStageSettings.Default)
        {
            ForceDefaultWeather(GameManager.GetWeatherTransitionComponent());
            return;
        }

        var actualWeatherStage = WeatherStageEnumMapping(Settings.Instance.ChooseWeatherStage);
        GameManager.GetWeatherTransitionComponent().ForceUnmanagedWeatherStage(actualWeatherStage, 0f);
    }

    private static void ForceDefaultWeather(WeatherTransition wt) => wt.ActivateDefaultWeatherSet();

    private static WeatherStage WeatherStageEnumMapping(WeatherStageSettings wss)
    {
        return wss switch
        {
            WeatherStageSettings.Default => WeatherStage.Undefined,
            WeatherStageSettings.Clear => WeatherStage.Clear,
            WeatherStageSettings.LightFog => WeatherStage.LightFog,
            WeatherStageSettings.DenseFog => WeatherStage.DenseFog,
            WeatherStageSettings.PartlyCloudy => WeatherStage.PartlyCloudy,
            WeatherStageSettings.Cloudy => WeatherStage.Cloudy,
            WeatherStageSettings.LightSnow => WeatherStage.LightSnow,
            WeatherStageSettings.HeavySnow => WeatherStage.HeavySnow,
            WeatherStageSettings.Blizzard => WeatherStage.Blizzard,
            WeatherStageSettings.GlimmerFog => WeatherStage.ElectrostaticFog,
            _ => throw new ArgumentException($"Unknown weather stage: {wss}"),
        };
    }
}