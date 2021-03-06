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
    public class BlockData : IBlockData
    {
        private const string FetchAllBlocks = "SPC_FetchAllBlocks";
        private const string FetchBlock = "SPC_FetchBlock";
        private const string AddBlocks = "SPC_AddBlock";
        public BlockData()
        {

        }

        public AddEditMasters AddBlock(BlockRequest bData)
        {
            try
            {
                string stProc = AddBlocks;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Block_gov_code", bData.blockGovCode),
                    new SqlParameter("@DistrictID", bData.districtId),
                    new SqlParameter("@Blockname", bData.blockName  ?? bData.blockName),
                    new SqlParameter("@Isactive", bData.isActive ?? bData.isActive),                  
                    new SqlParameter("@Comments", bData.comments ?? bData.comments),
                    new SqlParameter("@Createdby", bData.createdBy),
                    new SqlParameter("@Updatedby", bData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Block> Retrieve(int code)
        {
            string stProc = FetchBlock;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<Block>(stProc, pList);
            return allData;
        }

        public List<Block> Retrieve()
        {
            string stProc = FetchAllBlocks;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<Block>(stProc, pList);
            return allData;
        }
    }
}
