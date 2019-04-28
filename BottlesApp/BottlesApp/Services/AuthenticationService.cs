using BottlesApp.Extensions;
using BottlesApp.Models;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BottlesApp.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private IRepository _repository { get; }
        private ISettingsManager _settingsManager { get; }

        public bool IsAuthorized => _settingsManager.IsAuthorized;

        public AuthenticationService(IRepository repository, ISettingsManager settingsManager)
        {
            _repository = repository;
            _settingsManager = settingsManager;
        }

        public async Task<UserModel> LoginAsync(string username, string password)
        {
            await InitMockData();

            var hashedPassword = MD5.Create().GetMd5Hash(password);
            var user = await _repository.GetSingleInstanceAsync<UserModel>(u => u.Username == username && u.Password == hashedPassword);

            if (user != null)
            {
                _settingsManager.IsAuthorized = true;
                _settingsManager.UserId = user.Id;
            }

            return user;
        }

        public void Logout()
        {
            _settingsManager.Reset();
        }

        private Task InitMockData()
        {
            var initOne = _repository.SaveOrUpdateAsync(new UserModel { Id=45, Username = "Pidor", Password = "6e9665ab37ca1887a7e0179c5fac0dc0" });//1231
            var itinSecond = _repository.SaveOrUpdateAsync(new UserModel { Id=49, Username = "Alex", Password = "6e9665ab37ca1887a7e0179c5fac0dc0" });//1231

            return Task.WhenAll(initOne, itinSecond);
        }
    }
}
