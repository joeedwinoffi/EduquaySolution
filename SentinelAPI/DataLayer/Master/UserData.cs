using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.Contracts.V1.Request.Master;
using SentinelAPI.Models;
using SentinelAPI.Models.Masters.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Master
{
    public class UserData : IUserData
    {
        private const string FetchUserByUsername = "SPC_FetchUserByUsername";
        private const string AddUser = "SPC_AddUser";
        private const string AddNewOTP = "SPC_AddNewOTP";
        private const string VerifyOTP = "SPC_VerifyOTP";
        private const string passwordChange = "SPC_CreateNewPassword";


        public async Task<int> AddNewUserAsync(AddUserRequest addUser, string password)
        {
            var recInsert = 0;
            try
            {
                var stProc = AddUser;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UserRoleId", addUser.userRoleId),
                    new SqlParameter("@HospitalId", addUser.hospitalId),
                    new SqlParameter("@FirstName", addUser.firstName ?? addUser.firstName),
                    new SqlParameter("@MiddleName", addUser.middleName.ToCheckNull()),
                    new SqlParameter("@LastName", addUser.lastName.ToCheckNull()),
                    new SqlParameter("@Email", addUser.email.ToCheckNull()),
                    new SqlParameter("@ContactNo", addUser.contactNo.ToCheckNull()),
                    new SqlParameter("@Address", addUser.address.ToCheckNull()),
                    new SqlParameter("@Pincode", addUser.pincode.ToCheckNull()),
                    new SqlParameter("@StateID", addUser.stateId),
                    new SqlParameter("@DistrictID", addUser.districtId),
                    new SqlParameter("@UserName", addUser.userName),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@CreatedBy", addUser.createdBy),
                    new SqlParameter("@Comments", addUser.comments ?? string.Empty),
                    retVal
                };
                recInsert = Convert.ToInt32(UtilityDL.ExecuteNonQuery(stProc, pList, true));
                return recInsert;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      

        public async Task<List<UserPassword>> CheckPasswordAsync(Users user)
        {
            try
            {
                var stProc = FetchUserByUsername;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@Username", user.userName)
                };
                var userPassword = UtilityDL.FillData<UserPassword>(stProc, pList);
                return userPassword;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<Users>> FindByUsernameAsync(string userName)
        {
            var stProc = FetchUserByUsername;
            var pList = new List<SqlParameter>() { new SqlParameter("@Username", userName) };
            var userDetail = UtilityDL.FillData<Users>(stProc, pList);
            return userDetail;
        }

        public MsgDetail SendOTP(string userName, string otp)
        {
            try
            {
                var stProc = AddNewOTP;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@Username", userName ?? userName),
                    new SqlParameter("@OTP", otp ?? otp),
                };
                var msgDet = UtilityDL.FillEntity<MsgDetail>(stProc, pList);
                return msgDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MsgDetail ValidateOTP(OTPRequest oData)
        {
            try
            {
                var stProc = VerifyOTP;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@Username", oData.userName ?? oData.userName),
                    new SqlParameter("@OTP", oData.otp ?? oData.otp),
                };
                var msgDet = UtilityDL.FillEntity<MsgDetail>(stProc, pList);
                return msgDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MsgDetail ChangePassword(string userName, string password)
        {
            try
            {
                var stProc = passwordChange;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@Username", userName ?? userName),
                    new SqlParameter("@Password", password ?? password),
                };
                var msgDet = UtilityDL.FillEntity<MsgDetail>(stProc, pList);
                return msgDet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
