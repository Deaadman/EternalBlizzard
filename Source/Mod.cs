using EternalWeather.Properties;

namespace EternalWeather;

internal sealed class Mod : MelonMod
{
    public override void OnInitializeMelon() => Settings.OnLoad();

    [HarmonyPatch(typeof(PlayerManager), nameof(PlayerManager.TeleportPlayerAfterSceneLoad))]
    private class UpdateWeather
    {
        private static void Postfix() => SetWeatherStage.WeatherStageChange();
    }
}