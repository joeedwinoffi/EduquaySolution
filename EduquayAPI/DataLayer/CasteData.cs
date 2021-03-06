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
    public class CasteData : ICasteData
    {
        private const string FetchCastes = "SPC_FetchAllCaste";
        private const string FetchCaste = "SPC_FetchCaste";
        private const string AddCaste = "SPC_AddCaste";
        public CasteData()
        {


        }

        public AddEditMasters Add(CasteRequest cData)
        {
            try
            {
                string stProc = AddCaste;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Castename",  cData.casteName   ??  cData.casteName),
                    new SqlParameter("@Isactive",  cData.isActive ??  cData.isActive),
                    new SqlParameter("@Comments",  cData.comments ??  cData.comments),
                    new SqlParameter("@Createdby",  cData.createdBy),
                    new SqlParameter("@Updatedby",  cData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Caste> Retrieve(int code)
        {
            string stProc = FetchCaste;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<Caste>(stProc, pList);
            return allData;
        }

        public List<Caste> Retrieve()
        {
            string stProc = FetchCastes;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<Caste>(stProc, pList);
            return allData;
        }
    }

}
