using EduquayAPI.Models.LoadMasters;
using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MobileMaster
{
    public class MobileMasterData : IMobileMasterData
    {
        private const string FetchDistrict = "SPC_FetchDistrictByUser";
        private const string FetchCHC = "SPC_FetchCHCByUser";
        private const string FetchPHC = "SPC_FetchPHCByUser";
        private const string FetchSC = "SPC_FetchSCByUser";
        private const string FetchRI = "SPC_FetchRIByUser";
        private const string FetchAllReligion = "SPC_FetchAllReligion";
        private const string FetchAllCaste = "SPC_FetchAllCaste";
        private const string FetchAllCommunity = "SPC_FetchAllCommunity";
        private const string FetchCommunity = "SPC_FetchCommunityByCaste";
        private const string FetchAllGovIdType = "SPC_FetchAllGovIDType";
        private const string FetchConstantValues = "SPC_FetchMobileConstantData";
        private const string FetchILR = "SPC_FetchILRByRI";
        private const string FetchTestingCHC = "SPC_FetchTestingCHCByRI";
        private const string FetchAVD = "SPC_FetchAVDByRI";
        private const string FetchStates = "SPC_FetchAllStates";
        private const string CheckValidDevice = "SPC_CheckValidDevice";
        private const string FetchAllPostMTPFollowup = "SPC_FetchAllPostMTPFollowup";
        public MobileMasterData()
        {

        }
       

        public List<LoadILR> RetrieveILR(int riId)
        {
            string stProc = FetchILR;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", riId) };
            var allData = UtilityDL.FillData<LoadILR>(stProc, pList);
            return allData;
        }

        public List<LoadCHCs> RetrieveTestingCHC(int riId)
        {
            string stProc = FetchTestingCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", riId) };
            var allData = UtilityDL.FillData<LoadCHCs>(stProc, pList);
            return allData;
        }
        public List<LoadAVD> RetrieveAVD(int riId)
        {
            string stProc = FetchAVD;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", riId) };
            var allData = UtilityDL.FillData<LoadAVD>(stProc, pList);
            return allData;
        }
        public List<LoadCaste> RetrieveCaste()
        {
            string stProc = FetchAllCaste;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadCaste>(stProc, pList);
            return allData;
        }

        public List<LoadCHCs> RetrieveCHC(int userId)
        {
            string stProc = FetchCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadCHCs>(stProc, pList);
            return allData;
        }

        public List<LoadCommunity> RetrieveCommunity(int id)
        {
            string stProc = FetchCommunity;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<LoadCommunity>(stProc, pList);
            return allData;
        }

        public List<LoadCommunity> RetrieveCommunity()
        {
            string stProc = FetchAllCommunity;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadCommunity>(stProc, pList);
            return allData;
        }

        public List<LoadConstantValues> RetrieveConstantValues()
        {
            string stProc = FetchConstantValues;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadConstantValues>(stProc, pList);
            return allData;
        }

        public List<LoadDistricts> RetrieveDistrict(int userId)
        {
            string stProc = FetchDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadDistricts>(stProc, pList);
            return allData;
        }

        public List<LoadGovIDType> RetrieveGovIDType()
        {
            string stProc = FetchAllGovIdType;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadGovIDType>(stProc, pList);
            return allData;
        }

        public List<LoadPHCs> RetrievePHC(int userId)
        {
            string stProc = FetchPHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadPHCs>(stProc, pList);
            return allData;
        }

        public List<LoadReligion> RetrieveReligion()
        {
            string stProc = FetchAllReligion;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadReligion>(stProc, pList);
            return allData;
        }
        public List<LoadMobileRI> RetrieveRI(int userId)
        {
            string stProc = FetchRI;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadMobileRI>(stProc, pList);
            return allData;
        }

        public List<LoadSCs> RetrieveSC(int userId)
        {
            string stProc = FetchSC;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadSCs>(stProc, pList);
            return allData;
        }

        public List<LoadState> RetrieveState()
        {
            string stProc = FetchStates;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadState>(stProc, pList);
            return allData;
        }

        public Device CheckDevice(int userId, string deviceId)
        {
            string stProc = CheckValidDevice;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANMId", userId ),
                new SqlParameter("@DeviceId", deviceId ),

            };
            var allData = UtilityDL.FillEntity<Device>(stProc, pList);
            return allData;
        }

        public List<LoadFollowUps> RetrieveFollowups()
        {
            string stProc = FetchAllPostMTPFollowup;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadFollowUps>(stProc, pList);
            return allData;
        }
    }
}
