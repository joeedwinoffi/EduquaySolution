using EduquayAPI.Contracts.V1.Request.Pathologist;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Pathologist;
using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Pathologist
{
    public interface IPathologistService
    {
        Task<HPLCTestDetailResponse> HPLCResultDetail(int centralLabId);
        Task<HPLCDiagnosisDetailResponse> EditHPLCDiagnosisDetail(int centralLabId);
        List<HPLCResult> HPLCResult();
        Task<ServiceResponse> AddHPLCDiagnosisResult(AddHPLCDiagnosisResultRequest aData);
        List<PathologistSampleStatus> RetrieveSampleStatus();
        List<PathoReports> RetrivePathologistReports(PathoReportsRequest prData);
        Task<HPLCDiagnosisDetailResponse> FetchSrPathoHPLCDiagnosisDetail(int centralLabId);
        Task<PathologistReportResponse> RetrivePathologistReportsDetail(PathologistReportRequest rData);
    }
}
