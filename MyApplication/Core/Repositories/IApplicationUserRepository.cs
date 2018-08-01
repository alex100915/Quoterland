using System.Collections.Generic;
using MyApplication.Core.Models;

namespace MyApplication.Core.Repositories
{
    public interface IApplicationUserRepository
    {
        IEnumerable<ApplicationUser> GetAllApplicationUsers();
        ApplicationUser GetUserById(string userId);
        string GetUserIdByFullname(string fullname);
    }
}