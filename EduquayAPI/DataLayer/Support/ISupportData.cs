using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Models.AdminiSupport;
using EduquayAPI.Models.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Support
{
    public interface ISupportData
    {
        List<BarcodeErrorDetail> FetchErrorBarcodeDetails();
        List<BarcodeErrorDetail> FetchBarcodeDetailsForErrorCorrection(string barcodeNo);
        BarcodeErrorDetail FetchBarcodeExist(string barcodeNo);
        UpdateBarcodeMsg UpdateErrorBarcode(UpdateBarcodeRequest bData);
        List<BarcodeUpdationDetails> FetchUpdatedBarcodeDetails(string ids);
        List<BarcodeErrorDetail> FetchDetailsForRCHCorrection(string input);
        List<BarcodeErrorDetail> FetchRCHIDExists(string input);
        UpdateRCHIDMsg UpdateRCHId(UpdateRCHIDRequest rData);
        List<RCHUpdationDetails> FetchUpdatedRCHIDDetails(string ids);
        ANMCreation AddNewANM(AddANMRequest addUser, string password);
        List<BarcodeErrorDetail> FetchDetailsForLMPCorrection(FetchRequest rData);
        ErrorMsgDetail UpdateErrorLMP(UpdateLMPRequest bData);
        List<SSTErrorDetail> FetchDetailsForSSTCorrection(FetchRequest rData);
        ErrorMsgDetail UpdateErrorSST(UpdateSSTRequest bData);
        List<BarcodeErrorReportDetail> FetchBarcodeErrorReport(ReportRequest rData);
        List<LMPErrorReportDetail> FetchLMPErrorReport(ReportRequest rData);
        List<RCHErrorReportDetail> FetchRCHErrorReport(ReportRequest rData);
        List<SSTCorrectionReportDetail> FetchSSTErrorReport(ReportRequest rData);

    }
    public interface ISupportDataFactory
    {
        ISupportData Create();
    }
    public class SupportDataFactory : ISupportDataFactory
    {
        public ISupportData Create()
        {
            return new SupportData();
        }
    }
}
