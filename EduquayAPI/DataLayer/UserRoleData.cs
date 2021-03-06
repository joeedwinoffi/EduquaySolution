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
    public class UserRoleData : IUserRoleData
    {
        private const string FetchUserRoles = "SPC_FetchAllUserRole";
        private const string FetchUserRole = "SPC_FetchUserRole";
        private const string AddUserRole = "SPC_AddUserRole";
        public UserRoleData()
        {

        }

        public AddEditMasters Add(UserRoleRequest urData)
        {
            try
            {
                string stProc = AddUserRole;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@UserTypeID", urData.userTypeId),
                    new SqlParameter("@Userrolename", urData.userRoleName ?? urData.userRoleName),
                    new SqlParameter("@Isactive", urData.isActive ?? urData.isActive),
                    new SqlParameter("@Comments", urData.comments ?? urData.comments),
                    new SqlParameter("@Createdby", urData.createdBy),
                    new SqlParameter("@Updatedby", urData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<UserRole> Retrieve(int code)
        {
            string stProc = FetchUserRole;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<UserRole>(stProc, pList);
            return allData; throw new NotImplementedException();
        }

        public List<UserRole> Retrieve()
        {
            string stProc = FetchUserRoles;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<UserRole>(stProc, pList);
            return allData;
        }
    }
}
