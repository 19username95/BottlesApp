using BottlesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BottlesApp.Services
{
    public interface IUserProfileService
    {
        Task<UserProfileModel> GetCurrentUserAsync();
    }
}
