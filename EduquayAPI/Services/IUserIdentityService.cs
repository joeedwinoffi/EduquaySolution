using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;

namespace EduquayAPI.Services
{
    public interface IUserIdentityService
    {

        Task<AuthenticationResult> AddNewRegisterAsync(AddUserRequest user, string password);
        Task<AuthenticationResult> LoginAsync(string userName, string password);
        Task<AuthenticationResult> MobileLoginAsync(string userName, string password,string deviceId);
        Task<LoginResetResponse> ResetLogin(string userName, string password);

    }
}
