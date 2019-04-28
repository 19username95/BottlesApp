namespace BottlesApp.Services
{
    public interface ISettingsManager
    {
        int UserId { get; set; }
        bool IsAuthorized { get; set; }

        void Reset();
    }
}
