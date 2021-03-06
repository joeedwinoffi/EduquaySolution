using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class UserTypeData : IUserTypeData
    {

        private const string FetchUserTypes = "SPC_FetchAllUserType";
        private const string FetchUserType = "SPC_FetchUserType";
        private const string AddUserType = "SPC_AddUserType";
        public UserTypeData()
        {

        }
        public AddEditMasters Add(UserTypeRequest utData)
        {
            try
            {
                string stProc = AddUserType;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@UserType", utData.userTypeName ?? utData.userTypeName),
                    new SqlParameter("@Isactive", utData.isActive ?? utData.isActive),
                    new SqlParameter("@Comments", utData.comments ?? utData.comments),
                    new SqlParameter("@Createdby", utData.createdBy),
                    new SqlParameter("@Updatedby", utData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<UserType> Retrieve(int code)
        {
            string stProc = FetchUserType;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<UserType>(stProc, pList);
            return allData;
        }

        public List<UserType> Retrieve()
        {
            string stProc = FetchUserTypes;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<UserType>(stProc, pList);
            return allData;
        }
    }
}
