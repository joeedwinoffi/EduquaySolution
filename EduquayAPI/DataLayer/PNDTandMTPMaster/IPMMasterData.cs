using EduquayAPI.Models.PMMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.PNDTandMTPMaster
{
    public interface IPMMasterData
    {
        List<PMMaster> GetUserDistrict(int userId);
        List<PMMaster> GetCHCbyDistrict(int id);
        List<PMMaster> GetPHCbyCHC(int id);
        List<PMMaster> GetANMbyPHC(int id);
        List<PMMaster> GetCounsellor();
        List<PMMaster> GetPNDTObstetrician();
        List<PMMaster> GetMTPObstetrician();
        List<PMMaster> GetAllDistricts();
        List<PMMaster> GetAllProcedureofTesting();
        List<PMMaster> GetAllPNDTComplecations();
        List<PMMaster> GetAllPNDTDiagnosis();
        List<PMMaster> GetAllPNDTResultMaster();
        List<PMMaster> GetAllMTPComplications();
        List<PMMaster> GetAllMTPDischargeCondition();
        List<PMMaster> GetAllPostMTPFollowUp();
        List<PMMaster> GetDistrictByPNDTLocation(int pndtLocationId);
    }

    public interface IPMMasterDataFactory
    {
        IPMMasterData Create();
    }
    public class PMMasterDataFactory : IPMMasterDataFactory
    {
        public IPMMasterData Create()
        {
            return new PMMasterData();
        }
    }
}
