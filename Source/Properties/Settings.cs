namespace EternalWeather.Properties;

internal class Settings : JsonModSettings
{
    internal static Settings Instance { get; } = new();

    [Name("Weather Stage")] [Description("Select which weather stage will be infinite.")]
    public WeatherStageSettings ChooseWeatherStage = WeatherStageSettings.Default;

    protected override void OnChange(FieldInfo field, object? oldValue, object? newValue)
    {
        SetWeatherStage.WeatherStageChange();
        base.OnChange(field, oldValue, newValue);
    }

    internal static void OnLoad()
    {
        Instance.AddToModSettings(BuildInfo.GUIName);
        Instance.RefreshGUI();
    }
}