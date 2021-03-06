using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
namespace EduquayAPI.DataLayer
{
    public interface IUsersData
    {
        Task<List<User>> FindByEmailAsync(string email);
        Task<List<User>> FindByUsernameAsync(string userName);
        Task<int> AddNewUserAsync(AddUserRequest addUser,string password);
        Task<List<UsersPassword>> CheckPasswordAsync(User user);
        Task<MobileLogin>CheckMobileLogin(int userId, string userName, string deviceId);
        void AddLoginDetails(int userId, string userName, string deviceId,string loginFrom);
        Task<WebLogin> CheckWebLogin(int userId, string userName);
        Task<MobileLogin> ResetLogin(string userName);
        Task<MobileLogin> Logout(int anmId);
        List<User> Retrieve(int code);
        List<User> Retrieve();
        List<User> RetrieveByUserType(int userTypeId);
        List<User> RetrieveByUserRole(int userRoleId);
        List<User> RetrieveByEmail(string email);
        List<User> RetrieveByUsername(string username);
        MsgDetail SendOTP(string userName, string otp);
        MsgDetail ValidateOTP(OTPRequest oData);
        MsgDetail ChangePassword(string userName,string password);
    }
}
