using BottlesApp.Models;
using System.Threading.Tasks;

namespace BottlesApp.Services
{
    public interface IAuthenticationService
    {
        Task<UserModel> LoginAsync(string username, string hashedPassword);
        bool IsAuthorized { get; }
        void Logout();
    }
}
