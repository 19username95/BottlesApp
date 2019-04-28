using Plugin.Settings.Abstractions;

namespace BottlesApp.Services
{
    public class SettingsManager : ISettingsManager
    {
        private readonly ISettings _appSettings;

        public SettingsManager(ISettings settings)
        {
            _appSettings = settings;
        }

        public int UserId
        {
            get => _appSettings.GetValueOrDefault(nameof(UserId), default(int));
            set => _appSettings.AddOrUpdateValue(nameof(UserId), value);
        }
        public bool IsAuthorized
        {
            get => _appSettings.GetValueOrDefault(nameof(IsAuthorized), default(bool));
            set => _appSettings.AddOrUpdateValue(nameof(IsAuthorized), value);
        }

        public void Reset()
        {
            IsAuthorized = false;
            UserId = -1;
        }

    }
}
