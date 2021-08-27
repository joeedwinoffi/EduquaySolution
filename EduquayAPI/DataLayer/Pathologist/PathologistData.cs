using EduquayAPI.Contracts.V1.Request.Pathologist;
using EduquayAPI.Models;
using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Pathologist
{
    public class PathologistData : IPathologistData
    {
        private const string FetchPathoDiognosticSubjectsList = "SPC_FetchPathoDiognosticSubjectsList";
        private const string FetchAllHPLCResult = "SPC_FetchAllHPLCResult";
        private const string AddHPLCDiagnosisResults = "SPC_AddHPLCDiagnosisResult";
        private const string FetchPathoEditDiognosisSubjectsList = "SPC_FetchPathoEditDiognosisSubjectsList";
        private const string AddHPLCDiagnosisResultByAutomatic = "SPC_AddHPLCDiagnosisResultByAutomatic";
        private const string FetchPathologistSampleStatus = "SPC_FetchPathologistSampleStatus";
        private const string FetchPathoDiagnosisReports = "SPC_FetchPathoDiagnosisReports";
        private const string FetchSrPathoReferedSubjectsList = "SPC_FetchSrPathoReferedSubjectsList";

        #region New Reports
        private const string PathoDiagnosisCompletedReport = "SPC_PathoDiagnosisCompletedReport";
        private const string PathoDiagnosisPendingReport = "SPC_PathoDiagnosisPendingReport";
        private const string SrPathoDiagnosisReport = "SPC_SrPathoDiagnosisReport";
        #endregion

        public PathologistData()
        {

        }

        public string AddHPLCDiagnosisResult(AddHPLCDiagnosisResultRequest aData)
        {
            try
            {
                var stProc = AddHPLCDiagnosisResults;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", aData.uniqueSubjectId ?? aData.uniqueSubjectId),
                    new SqlParameter("@CentralLabId", aData.centralLabId),
                    new SqlParameter("@BarcodeNo", aData.barcodeNo ?? aData.barcodeNo),
                    new SqlParameter("@HPLCTestResultId", aData.hplcTestResultId),
                    new SqlParameter("@ClinicalDiagnosisId", aData.clinicalDiagnosisId ?? aData.clinicalDiagnosisId),
                    new SqlParameter("@HPLCResultMasterId", aData.hplcResultMasterId ?? aData.hplcResultMasterId),
                    new SqlParameter("@IsNormal", aData.isNormal),
                    new SqlParameter("@DiagnosisSummary", aData.diagnosisSummary ?? aData.diagnosisSummary),
                    new SqlParameter("@IsConsultSeniorPathologist", aData.isConsultSeniorPathologist),
                    new SqlParameter("@SeniorPathologistName", aData.seniorPathologistName  ?? aData.seniorPathologistName),
                    new SqlParameter("@SeniorPathologistRemarks", aData.seniorPathologistRemarks  ?? aData.seniorPathologistRemarks),
                    new SqlParameter("@CreatedBy", aData.userId ),
                    new SqlParameter("@IsDiagnosisComplete", aData.isDiagnosisComplete),
                    new SqlParameter("@OthersResult", aData.othersResult.ToCheckNull()),
                    new SqlParameter("@OthersDiagnosis", aData.othersDiagnosis.ToCheckNull()),

                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return $"HPLC diagnosis result updated successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AutomaticHPLCDiagnosisUpdate(int centralLabId)
        {
            try
            {
                var stProc = AddHPLCDiagnosisResultByAutomatic;
                var pList = new List<SqlParameter>()
                {
                     new SqlParameter("@CentralLabId", centralLabId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HPLCDiagnosisDetails> EditHPLCDiagnosisDetail(int centralLabId)
        {
            string stProc = FetchPathoEditDiognosisSubjectsList;
            var pList = new List<SqlParameter>() { new SqlParameter("@CentralLabId", centralLabId) };
            var allSampleData = UtilityDL.FillData<HPLCDiagnosisDetails>(stProc, pList);
            return allSampleData;
        }

        public List<HPLCDiagnosisDetails> FetchSrPathoHPLCDiagnosisDetail(int centralLabId)
        {
            string stProc = FetchSrPathoReferedSubjectsList;
            var pList = new List<SqlParameter>() { new SqlParameter("@CentralLabId", centralLabId) };
            var allSampleData = UtilityDL.FillData<HPLCDiagnosisDetails>(stProc, pList);
            return allSampleData;
        }

        public List<HPLCResult> HPLCResult()
        {
            string stProc = FetchAllHPLCResult;
            var pList = new List<SqlParameter>();
            var hplcResult = UtilityDL.FillData<HPLCResult>(stProc, pList);
            return hplcResult;
        }

        public List<HPLCTestDetails> HPLCResultDetail(int centralLabId)
        {
            string stProc = FetchPathoDiognosticSubjectsList;
            var pList = new List<SqlParameter>() { new SqlParameter("@CentralLabId", centralLabId) };
            var allSampleData = UtilityDL.FillData<HPLCTestDetails>(stProc, pList);
            return allSampleData;
        }

        public List<PathologistReports> RetrieveDiagnosisCompletedDetails(PathologistReportRequest rData)
        {
            string stProc = PathoDiagnosisCompletedReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@SubjectType", rData.subjectType),
                new SqlParameter("@CentralLabID", rData.centralLabId),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<PathologistReports>(stProc, pList);
            return allData;
        }

        public List<PathologistReports> RetrieveDiagnosisPendingDetails(PathologistReportRequest rData)
        {
            string stProc = PathoDiagnosisPendingReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@SubjectType", rData.subjectType),
                new SqlParameter("@CentralLabID", rData.centralLabId),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<PathologistReports>(stProc, pList);
            return allData;
        }

        public List<PathologistSampleStatus> RetrieveSampleStatus()
        {
            string stProc = FetchPathologistSampleStatus;
            var pList = new List<SqlParameter>();

            var allSampleStatus = UtilityDL.FillData<PathologistSampleStatus>(stProc, pList);
            return allSampleStatus;
        }

        public List<PathologistReports> RetrieveSrPathoDiagnosisDetails(PathologistReportRequest rData)
        {
            string stProc = SrPathoDiagnosisReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@SubjectType", rData.subjectType),
                new SqlParameter("@CentralLabID", rData.centralLabId),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<PathologistReports>(stProc, pList);
            return allData;
        }

        public List<PathoReports> RetrivePathologistReports(PathoReportsRequest prData)
        {
            string stProc = FetchPathoDiagnosisReports;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SampleStatus", prData.sampleStatus),
                new SqlParameter("@CentralLabId", prData.centrelLabId),
                new SqlParameter("@CHCID", prData.chcId),
                new SqlParameter("@PHCID", prData.phcId),
                new SqlParameter("@ANMID", prData.anmId),
                new SqlParameter("@FromDate", prData.fromDate.ToCheckNull()),
                new SqlParameter("@ToDate", prData.toDate.ToCheckNull()),
            };
            var allReceivedSubject = UtilityDL.FillData<PathoReports>(stProc, pList);
            return allReceivedSubject;
        }
    }
}
