
using DatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.BusinessLayer.Service.Repository
{
   public interface IUserRepository
    {
        Task<String> CreateNewUser(User user);

        Task<User> VerifyUser(String UserName, String Password);

        Task<Profile> AddProfile(Profile profile);

        Task<IEnumerable<User>> ListOfMembers();

        Task<String> ChangePassword(String UserName, String NewPassword);

        Task<String> SuspendUser(String UserName, UserStatus userStatus);

    }
}
