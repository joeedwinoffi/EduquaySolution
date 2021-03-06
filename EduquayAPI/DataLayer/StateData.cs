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
    public class StateData : IStateData
    {

        private const string FetchStates = "SPC_FetchAllStates";
        private const string FetchState = "SPC_FetchState";
        private const string AddState = "SPC_AddState";
        public StateData()
        {

        }
        public AddEditMasters Add(StateRequest state)
        {
            try
            {
                string stProc = AddState;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@State_gov_code", state.stateGovCode ?? state.stateGovCode),
                    new SqlParameter("@Statename", state.stateName ?? state.stateName),
                    new SqlParameter("@Shortname", state.shortName ?? state.shortName),
                    new SqlParameter("@Isactive", state.isActive ?? state.isActive),
                    new SqlParameter("@Comments", state.comments ?? state.comments),
                    new SqlParameter("@Createdby", state.createdBy),
                    new SqlParameter("@Updatedby", state.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<State> Retrieve(int code)
        {
            string stProc = FetchState;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<State>(stProc, pList);
            return allData;
        }
        public List<State> Retrieve()
        {
            string stProc = FetchStates;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<State>(stProc, pList);
            return allData;
        }
    }
}
