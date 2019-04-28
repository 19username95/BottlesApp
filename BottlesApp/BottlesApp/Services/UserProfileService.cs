using BottlesApp.Models;
using System.Threading.Tasks;

namespace BottlesApp.Services
{
    public class UserProfileService : IUserProfileService
    {
        private IRepository _repository { get; }
        private ISettingsManager _settingsManager { get; }

        public UserProfileService(IRepository repository, ISettingsManager settingsManager)
        {
            _repository = repository;
            _settingsManager = settingsManager;
        }

        public async Task<UserProfileModel> GetCurrentUserAsync()
        {
            await InitMockData();

            var userId = _settingsManager.UserId;
            var userResult = await _repository.GetSingleInstanceAsync<UserProfileModel>(u => u.UserModelId == userId);

            return userResult;
        }


        private async Task InitMockData()
        {
            var users = await _repository.GetAllAsync<UserModel>();

            foreach (var user in users)
            {
                await _repository.SaveOrUpdateAsync(new UserProfileModel
                {
                    Id = user.Id,
                    UserModelId = user.Id,
                    Name = user.Username.ToUpper(),
                    BottlesSaved = user.Id,
                    CarboneSaved = 152+user.Id
                });
            }
        }
    }
}
