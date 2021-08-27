using EduquayAPI.Contracts.V1.Request.Pathologist;
using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Pathologist
{
    public interface IPathologistData
    {
        List<HPLCTestDetails> HPLCResultDetail(int centralLabId);
        List<HPLCDiagnosisDetails> EditHPLCDiagnosisDetail(int centralLabId);
        List<HPLCResult> HPLCResult();
        string AddHPLCDiagnosisResult(AddHPLCDiagnosisResultRequest aData);
        void AutomaticHPLCDiagnosisUpdate(int centralLabId);
        List<PathologistSampleStatus> RetrieveSampleStatus();
        List<PathoReports> RetrivePathologistReports(PathoReportsRequest prData);
        List<HPLCDiagnosisDetails> FetchSrPathoHPLCDiagnosisDetail(int centralLabId);
        List<PathologistReports> RetrieveDiagnosisCompletedDetails(PathologistReportRequest rData);
        List<PathologistReports> RetrieveDiagnosisPendingDetails(PathologistReportRequest rData);
        List<PathologistReports> RetrieveSrPathoDiagnosisDetails(PathologistReportRequest rData);
    }

    public interface IPathologistDataFactory
    {
        IPathologistData Create();
    }
    public class PathologistDataFactory : IPathologistDataFactory
    {
        public IPathologistData Create()
        {
            return new PathologistData();
        }
    }
}
