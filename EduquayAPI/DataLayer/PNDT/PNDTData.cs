using EduquayAPI.Contracts.V1.Request.PNDTC;
using EduquayAPI.Models;
using EduquayAPI.Models.PNDT;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.PNDT
{
    public class PNDTData : IPNDTData
    {
        private const string FetchSubjectsPrePNDTScheduling = "SPC_FetchSubjectsPrePNDTScheduling";
        private const string FetchSubjectsPrePNDTScheduled = "SPC_FetchSubjectsPrePNDTScheduled";
        private const string AddPrePNDTScheduling = "SPC_AddPrePNDTScheduling";
        private const string FetchSubjectsPrePNDTCounselling = "SPC_FetchSubjectsPrePNDTCounselling";
        private const string AddPrePNDTCounselling = "SPC_AddPrePNDTCounselling";
        private const string FetchSubjectsPrePNDTCounseledYes = "SPC_FetchSubjectsPrePNDTCounseledYes";
        private const string FetchSubjectsPrePNDTCounseledNo = "SPC_FetchSubjectsPrePNDTCounseledNo";
        private const string FetchSubjectsPrePNDTCounseledPending = "SPC_FetchSubjectsPrePNDTCounseledPending";
        private const string UpdatePrePNDTCounsellingByAutomatic = "SPC_UpdatePrePNDTCounsellingByAutomatic";

        private const string FetchSubjectsPostPNDTScheduling = "SPC_FetchSubjectsPostPNDTScheduling";
        private const string AddPostPNDTsScheduling = "SPC_AddPostPNDTScheduling";
        private const string FetchSubjectsPostPNDTScheduled = "SPC_FetchSubjectsPostPNDTScheduled";
        private const string FetchSubjectsPostPNDTCounselling = "SPC_FetchSubjectsPostPNDTCounselling";
        private const string AddPostCounselling = "SPC_AddPostPNDTCounselling";
        private const string FetchSubjectsPostPNDTCounselledYes = "SPC_FetchSubjectsPostPNDTCounselledYes";
        private const string FetchSubjectsPostPNDTCounselledNo = "SPC_FetchSubjectsPostPNDTCounselledNo";
        private const string FetchSubjectsPostPNDTCounselledPending = "SPC_FetchSubjectsPostPNDTCounselledPending";
        private const string UpdatePostPNDTCounsellingByAutomatic = "SPC_UpdatePostPNDTCounsellingByAutomatic";
        private const string FetchPNDTPickAndPack = "SPC_FetchPNDTPickAndPack";
        private const string AddPNDTShipments = "SPC_AddPNDTShipments";
        private const string FetchPNDTShipmentLog = "SPC_FetchPNDTShipmentLog";

        public PNDTData()
        {

        }
        public PNDTShipmentList RetrieveShipmentLog(int pndtLocationId)
        {
            string stProc = FetchPNDTShipmentLog;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PNDTLocationId", pndtLocationId),
               
            };
            var allShipmentLogs = UtilityDL.FillData<PNDTShipmentLogs>(stProc, pList);
            var allShipmentSubjects = UtilityDL.FillData<PNDTShipmentLogsDetail>(stProc, pList);
            var shiplogDetail = new PNDTShipmentList();
            shiplogDetail.ShipmentLog = allShipmentLogs;
            shiplogDetail.ShipmentSubjectDetail = allShipmentSubjects;
            return shiplogDetail;
        }

        public List<PNDTPickAndPack> RetrievePickAndPack(int pndtLocationId)
        {
            string stProc = FetchPNDTPickAndPack;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PNDTLocationId", pndtLocationId),
            };
            var allData = UtilityDL.FillData<PNDTPickAndPack>(stProc, pList);
            return allData;
        }
        public List<PNDTShipments> AddPNDTShipment(AddPNDTShipmentRequest sData)
        {
            string stProc = AddPNDTShipments;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PNDTFoetusId", sData.pndtFoetusId ?? sData.pndtFoetusId),
                new SqlParameter("@SenderName", sData.senderName ?? sData.senderName),
                new SqlParameter("@SenderContact", sData.senderContact ?? sData.senderContact),
                new SqlParameter("@SendingLocation", sData.sendingLocation ?? sData.sendingLocation),
                new SqlParameter("@ReceivingMolecularLabId", sData.receivingMolecularLabId),
                new SqlParameter("@ShipmentDateTime", sData.shipmentDateTime ?? sData.shipmentDateTime),
                new SqlParameter("@PDNTLocationId", sData.pndtLocationId),
                new SqlParameter("@UserId", sData.userId),
            };
            var shipmentData = UtilityDL.FillData<PNDTShipments>(stProc, pList);
            return shipmentData;
        }

        public PrePNDTScheduleDateTime AddCounselling(AddPrePNDTCounsellingRequest acData)
        {
            string stProc = AddPrePNDTCounselling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PrePNDTSchedulingId", acData.prePNDTSchedulingId),
                new SqlParameter("@ANWSubjectId", acData.anwsubjectId ?? acData.anwsubjectId),
                new SqlParameter("@SpouseSubjectId", acData.spouseSubjectId ?? acData.spouseSubjectId),
                new SqlParameter("@CounsellingRemarks", acData.counsellingRemarks ?? acData.counsellingRemarks),
                new SqlParameter("@AssignedObstetricianId", acData.assignedObstetricianId),
                new SqlParameter("@CounsellorId", acData.counsellorId),
                new SqlParameter("@IsPNDTAgreeYes", acData.isPNDTAgreeYes),
                new SqlParameter("@IsPNDTAgreeNo", acData.isPNDTAgreeNo),
                new SqlParameter("@IsPNDTAgreePending", acData.isPNDTAgreePending),
                new SqlParameter("@SchedulePNDTDate", acData.schedulePNDTDate ?? acData.schedulePNDTDate),
                new SqlParameter("@SchedulePNDTtime", acData.schedulePNDTTime ?? acData.schedulePNDTTime),
                new SqlParameter("@FileName", acData.fileName.ToCheckNull()),
                new SqlParameter("@FileLocation", acData.fileLocation.ToCheckNull()),
                new SqlParameter("@CreatedBy", acData.userId),
            };
            var schedulingData = UtilityDL.FillEntity<PrePNDTScheduleDateTime>(stProc, pList);
            return schedulingData;
        }

        public CounsellingDateTime AddScheduling(AddSchedulingRequest asData)
        {
            string stProc = AddPrePNDTScheduling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANWSubjectId", asData.anwsubjectId ?? asData.anwsubjectId),
                new SqlParameter("@SpouseSubjectId", asData.spouseSubjectId ?? asData.spouseSubjectId),
                new SqlParameter("@CounsellorId", asData.counsellorId),
                new SqlParameter("@CounsellingDateTime", asData.counsellingDateTime ?? asData.counsellingDateTime),
                new SqlParameter("@CreatedBy", asData.userId),
            };
            var schedulingData = UtilityDL.FillEntity<CounsellingDateTime>(stProc, pList);
            return schedulingData;
        }

        public void AutomaticPrePNDTCousellingUpdate()
        {
            try
            {
                var stProc = UpdatePrePNDTCounsellingByAutomatic;
                var pList = new List<SqlParameter>();
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PrePNDTScheduling> GetPositiveSubjectsScheduling(PNDTSchedulingRequest psData)
        {
            string stProc = FetchSubjectsPrePNDTScheduling;
            var pList = new List<SqlParameter>()
            { 
                new SqlParameter("@UserId", psData.userId),
                new SqlParameter("@DistrictId", psData.districtId),
                new SqlParameter("@CHCId", psData.chcId),
                new SqlParameter("@PHCId", psData.phcId),
                new SqlParameter("@ANMId", psData.anmId)
            };
            var schedulingData = UtilityDL.FillData<PrePNDTScheduling>(stProc, pList);
            return schedulingData;
        }

        public List<PostPNDTScheduling> GetPostPNDTScheduling(PNDTSchedulingRequest psData)
        {
            string stProc = FetchSubjectsPostPNDTScheduling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", psData.userId),
                new SqlParameter("@DistrictId", psData.districtId),
                new SqlParameter("@CHCId", psData.chcId),
                new SqlParameter("@PHCId", psData.phcId),
                new SqlParameter("@ANMId", psData.anmId)
            };
            var schedulingData = UtilityDL.FillData<PostPNDTScheduling>(stProc, pList);
            return schedulingData;
        }

        public List<PrePNDTCounselling> GetScheduledForCounselling(PNDTSchedulingRequest psData)
        {
            string stProc = FetchSubjectsPrePNDTCounselling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", psData.userId),
                new SqlParameter("@DistrictId", psData.districtId),
                new SqlParameter("@CHCId", psData.chcId),
                new SqlParameter("@PHCId", psData.phcId),
                new SqlParameter("@ANMId", psData.anmId)
            };
            var counsellingData = UtilityDL.FillData<PrePNDTCounselling>(stProc, pList);
            return counsellingData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledNo(PNDTSchedulingRequest pcData)
        {
            string stProc = FetchSubjectsPrePNDTCounseledNo;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", pcData.userId),
                new SqlParameter("@DistrictId", pcData.districtId),
                new SqlParameter("@CHCId", pcData.chcId),
                new SqlParameter("@PHCId", pcData.phcId),
                new SqlParameter("@ANMId", pcData.anmId)
            };
            var counseledNoData = UtilityDL.FillData<PrePNDTCounselled>(stProc, pList);
            return counseledNoData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledPending(PNDTSchedulingRequest pcData)
        {
            string stProc = FetchSubjectsPrePNDTCounseledPending;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", pcData.userId),
                new SqlParameter("@DistrictId", pcData.districtId),
                new SqlParameter("@CHCId", pcData.chcId),
                new SqlParameter("@PHCId", pcData.phcId),
                new SqlParameter("@ANMId", pcData.anmId)
            };
            var counseledPendingData = UtilityDL.FillData<PrePNDTCounselled>(stProc, pList);
            return counseledPendingData;
        }

        public List<PrePNDTCounselled> GetSubjectsCounselledYes(PNDTSchedulingRequest pcData)
        {
            string stProc = FetchSubjectsPrePNDTCounseledYes;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", pcData.userId),
                new SqlParameter("@DistrictId", pcData.districtId),
                new SqlParameter("@CHCId", pcData.chcId),
                new SqlParameter("@PHCId", pcData.phcId),
                new SqlParameter("@ANMId", pcData.anmId)
            };
            var counseledYesData = UtilityDL.FillData<PrePNDTCounselled>(stProc, pList);
            return counseledYesData;
        }

        public List<PrePNDTScheduled> GetSubjectsScheduled(PNDTSchedulingRequest psData)
        {
            string stProc = FetchSubjectsPrePNDTScheduled;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", psData.userId),
                new SqlParameter("@DistrictId", psData.districtId),
                new SqlParameter("@CHCId", psData.chcId),
                new SqlParameter("@PHCId", psData.phcId),
                new SqlParameter("@ANMId", psData.anmId)
            };
            var scheduledData = UtilityDL.FillData<PrePNDTScheduled>(stProc, pList);
            return scheduledData;
        }

        public CounsellingDateTime AddPostPNDTScheduling(AddSchedulingRequest asData)
        {
            string stProc = AddPostPNDTsScheduling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANWSubjectId", asData.anwsubjectId ?? asData.anwsubjectId),
                new SqlParameter("@SpouseSubjectId", asData.spouseSubjectId ?? asData.spouseSubjectId),
                new SqlParameter("@CounsellorId", asData.counsellorId),
                new SqlParameter("@CounsellingDateTime", asData.counsellingDateTime ?? asData.counsellingDateTime),
                new SqlParameter("@CreatedBy", asData.userId),
            };
            var schedulingData = UtilityDL.FillEntity<CounsellingDateTime>(stProc, pList);
            return schedulingData;
        }

        public List<PostPNDTScheduled> GetSubjectsPostPNDTScheduled(PNDTSchedulingRequest psData)
        {
            string stProc = FetchSubjectsPostPNDTScheduled;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", psData.userId),
                new SqlParameter("@DistrictId", psData.districtId),
                new SqlParameter("@CHCId", psData.chcId),
                new SqlParameter("@PHCId", psData.phcId),
                new SqlParameter("@ANMId", psData.anmId)
            };
            var scheduledData = UtilityDL.FillData<PostPNDTScheduled>(stProc, pList);
            return scheduledData;
        }

        public PostPNDTCounsellingDetail GetScheduledForPostPNDTCounselling(PNDTSchedulingRequest psData)
        {
            string stProc = FetchSubjectsPostPNDTCounselling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", psData.userId),
                new SqlParameter("@DistrictId", psData.districtId),
                new SqlParameter("@CHCId", psData.chcId),
                new SqlParameter("@PHCId", psData.phcId),
                new SqlParameter("@ANMId", psData.anmId)
            };
            var allANWDetail = UtilityDL.FillData<PostPNDTCounselling>(stProc, pList);
            var allFoetusDetail = UtilityDL.FillData<PNDTFoetusDetail>(stProc, pList);
            var counsellingData = new PostPNDTCounsellingDetail();
            counsellingData.anwDetail = allANWDetail;
            counsellingData.foetusDetail = allFoetusDetail;
            return counsellingData;
        }

        public MTPScheduleDateTime AddPostPNDTCounselling(AddPostPNDTCounsellingRequest acData)
        {
            string stProc = AddPostCounselling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PostPNDTSchedulingId", acData.postPNDTSchedulingId),
                new SqlParameter("@ANWSubjectId", acData.anwsubjectId ?? acData.anwsubjectId),
                new SqlParameter("@CounsellorId", acData.counsellorId),
                new SqlParameter("@SpouseSubjectId", acData.spouseSubjectId ?? acData.spouseSubjectId),
                new SqlParameter("@CounsellingRemarks", acData.counsellingRemarks ?? acData.counsellingRemarks),
                new SqlParameter("@AssignedObstetricianId", acData.assignedObstetricianId),
                new SqlParameter("@IsMTPAgreeYes", acData.isMTPAgreeYes),
                new SqlParameter("@IsMTPAgreeNo", acData.isMTPAgreeNo),
                new SqlParameter("@IsMTPAgreePending", acData.isMTPAgreePending),
                new SqlParameter("@ScheduleMTPDate", acData.scheduleMTPDate ?? acData.scheduleMTPDate),
                new SqlParameter("@ScheduleMTPTime", acData.scheduleMTPTime ?? acData.scheduleMTPTime),
                new SqlParameter("@FileName", acData.fileName.ToCheckNull()),
                new SqlParameter("@FileLocation", acData.fileLocation.ToCheckNull()),
                new SqlParameter("@CreatedBy", acData.userId),
            };
            var schedulingData = UtilityDL.FillEntity<MTPScheduleDateTime>(stProc, pList);
            return schedulingData;
        }

        public PostPNDTCounselledDetail GetSubjectsPostPNDTCounselledYes(PNDTSchedulingRequest pcData)
        {
            string stProc = FetchSubjectsPostPNDTCounselledYes;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", pcData.userId),
                new SqlParameter("@DistrictId", pcData.districtId),
                new SqlParameter("@CHCId", pcData.chcId),
                new SqlParameter("@PHCId", pcData.phcId),
                new SqlParameter("@ANMId", pcData.anmId)
            };

            var allANWDetail = UtilityDL.FillData<PostPNDTCounselled>(stProc, pList);
            var allFoetusDetail = UtilityDL.FillData<PNDTFoetusDetail>(stProc, pList);
            var counseledYesData = new PostPNDTCounselledDetail();
            counseledYesData.anwDetail = allANWDetail;
            counseledYesData.foetusDetail = allFoetusDetail;
            return counseledYesData;
        }

        public PostPNDTCounselledDetail GetSubjectsPostPNDTCounselledNo(PNDTSchedulingRequest pcData)
        {
            string stProc = FetchSubjectsPostPNDTCounselledNo;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", pcData.userId),
                new SqlParameter("@DistrictId", pcData.districtId),
                new SqlParameter("@CHCId", pcData.chcId),
                new SqlParameter("@PHCId", pcData.phcId),
                new SqlParameter("@ANMId", pcData.anmId)
            };
            var allANWDetail = UtilityDL.FillData<PostPNDTCounselled>(stProc, pList);
            var allFoetusDetail = UtilityDL.FillData<PNDTFoetusDetail>(stProc, pList);
            var counseledNoData = new PostPNDTCounselledDetail();
            counseledNoData.anwDetail = allANWDetail;
            counseledNoData.foetusDetail = allFoetusDetail;
            return counseledNoData;
        }

        public PostPNDTCounselledDetail GetSubjectsPostPNDTCounselledPending(PNDTSchedulingRequest pcData)
        {
            string stProc = FetchSubjectsPostPNDTCounselledPending;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", pcData.userId),
                new SqlParameter("@DistrictId", pcData.districtId),
                new SqlParameter("@CHCId", pcData.chcId),
                new SqlParameter("@PHCId", pcData.phcId),
                new SqlParameter("@ANMId", pcData.anmId)
            };
            var allANWDetail = UtilityDL.FillData<PostPNDTCounselled>(stProc, pList);
            var allFoetusDetail = UtilityDL.FillData<PNDTFoetusDetail>(stProc, pList);
            var counseledPendingData = new PostPNDTCounselledDetail();
            counseledPendingData.anwDetail = allANWDetail;
            counseledPendingData.foetusDetail = allFoetusDetail;
            return counseledPendingData;
        }

        public void AutomaticPostPNDTCousellingUpdate()
        {
            try
            {
                var stProc = UpdatePostPNDTCounsellingByAutomatic;
                var pList = new List<SqlParameter>();
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
    }
}
