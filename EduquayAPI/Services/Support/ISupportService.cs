using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.AdminSupport;
using EduquayAPI.Contracts.V1.Response.Support;
using EduquayAPI.Models.Support;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.Support
{
    public interface ISupportService
    {
        List<BarcodeErrorDetail> FetchErrorBarcodeDetails();
        List<BarcodeErrorDetail> FetchBarcodeDetailsForErrorCorrection(string barcodeNo);
        Task<CheckBarcodeResponse> CheckbarcodeExist(string barcodeNo);
        Task<ServiceResponse> UpdateErrorBarcode(UpdateBarcodeRequest bData);
        List<BarcodeErrorDetail> FetchDetailsForRCHCorrection(string input);
        List<BarcodeErrorDetail> FetchDetailsForLMPCorrection(FetchRequest rData);
        Task<ServiceResponse> UpdateRCHId(UpdateRCHIDRequest rData);
        Task<CheckRCHResponse> CheckRCHIDExist(string rchId);
        Task<ServiceResponse> UpdateLMP(UpdateLMPRequest rData);
        Task<ServiceResponse> UpdateSST(UpdateSSTRequest rData);
        Task<AddANMResponse> AddNewANMUser(AddANMRequest aData);
        List<SSTErrorDetail> FetchDetailsForSSTCorrection(FetchRequest rData);
        List<BarcodeErrorReportDetail> FetchBarcodeErrorReport(ReportRequest rData);
        List<LMPErrorReportDetail> FetchLMPErrorReport(ReportRequest rData);
        List<RCHErrorReportDetail> FetchRCHErrorReport(ReportRequest rData);
        List<SSTCorrectionReportDetail> FetchSSTErrorReport(ReportRequest rData);

        Task<UploadFileResponse> UploadCBCHPLCFiles(List<IFormFile> files);

    }
}
