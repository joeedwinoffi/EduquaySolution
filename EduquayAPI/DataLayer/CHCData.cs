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
    public class CHCData : ICHCData
    {
        private const string FetchAllCHCs = "SPC_FetchAllCHC";
        private const string FetchCHC = "SPC_FetchCHC";
        private const string AddCHC = "SPC_AddCHC";
        public CHCData()
        {

        }

        public AddEditMasters Add(CHCRequest cData)
        {
            try
            {
                string stProc = AddCHC;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BlockID", cData.blockId),
                    new SqlParameter("@DistrictID", cData.districtId),
                    new SqlParameter("@HNIN_ID", cData.hninId ?? cData.hninId),
                    new SqlParameter("@CHC_gov_code", cData.chcGovCode),
                    new SqlParameter("@CHCname", cData.chcName  ?? cData.chcName),
                    new SqlParameter("@Istestingfacility", cData.isTestingFacility ?? cData.isTestingFacility),
                    new SqlParameter("@TestingCHCID", cData.testingCHCId),
                    new SqlParameter("@CentralLabId", cData.centralLabId),
                    new SqlParameter("@Pincode", cData.pincode ?? cData.pincode),
                    new SqlParameter("@Isactive", cData.isActive ?? cData.isActive),
                    new SqlParameter("@Latitude", cData.latitude ?? cData.latitude),
                    new SqlParameter("@Longitude", cData.longitude ?? cData.longitude),
                    new SqlParameter("@Comments", cData.comments ?? cData.comments),
                    new SqlParameter("@Createdby", cData.createdBy),
                    new SqlParameter("@Updatedby", cData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CHC> Retrieve(int code)
        {
            string stProc = FetchCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<CHC>(stProc, pList);
            return allData;
        }

        public List<CHC> Retrieve()
        {
            string stProc = FetchAllCHCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<CHC>(stProc, pList);
            return allData;
        }
    }
}
