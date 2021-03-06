using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class FacilityTypeData : IFacilityTypeData
    {


        private const string FetchFacilityTypes = "SPC_FetchAllFacilityType";
        private const string FetchFacilityType = "SPC_FetchFacilityType";
        private const string AddFacilityType = "SPC_AddFacilityType";
        public FacilityTypeData()
        {

        }
        public string Add(FacilityTypeRequest ftData)
        {
            try
            {
                string stProc = AddFacilityType;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Facility_typename", ftData.facilityTypeName ?? ftData.facilityTypeName),
                    new SqlParameter("@Isactive", ftData.isActive ?? ftData.isActive),                   
                    new SqlParameter("@Comments", ftData.comments ?? ftData.comments),
                    new SqlParameter("@Createdby", ftData.createdBy),
                    new SqlParameter("@Updatedby", ftData.updatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Facility Type added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<FacilityType> Retrieve(int code)
        {
            string stProc = FetchFacilityType;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<FacilityType>(stProc, pList);
            return allData;
        }

        public List<FacilityType> Retrieve()
        {
            string stProc = FetchFacilityTypes;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<FacilityType>(stProc, pList);
            return allData;
        }
    }
}
