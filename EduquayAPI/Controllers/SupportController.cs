using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.AdminSupport;
using EduquayAPI.Contracts.V1.Response.Support;
using EduquayAPI.Models.Support;
using EduquayAPI.Services.Support;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService _supportService;
        private readonly ILogger<SupportController> _logger;
        public SupportController(ISupportService supportService, ILogger<SupportController> logger)
        {
            _supportService = supportService;
            _logger = logger;
        }

        /// <summary>
        /// Used for fetch the error Barcodes detail for error correction
        /// </summary>
        [HttpGet]
        [Route("RetrieveErrorBarcodeDetails")]
        public ErrorBarcodeDetailResponse FetchErrorBarcodeDetail()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorBarcodes = _supportService.FetchErrorBarcodeDetails();

                _logger.LogInformation($"Received Error barcode data {errorBarcodes}");
                return errorBarcodes.Count == 0 ?
                    new ErrorBarcodeDetailResponse { status = "true", message = "No record found", data = new List<BarcodeErrorDetail>() }
                    : new ErrorBarcodeDetailResponse { status = "true", message = string.Empty, data = errorBarcodes };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving error barcode data {e.StackTrace}");
                return new ErrorBarcodeDetailResponse { status = "false", message = e.Message, data = null };
            }
        }


        /// <summary>
        /// Used for fetch the Barcode detail for error correction
        /// </summary>

        [HttpGet]
        [Route("RetrieveBarcodeDetailsForErrorCorrection/{barcodeNo}")]
        public ErrorBarcodeDetailResponse FetchBarcodeDetailForCorrection(string barcodeNo)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorBarcodes = _supportService.FetchBarcodeDetailsForErrorCorrection(barcodeNo);

                _logger.LogInformation($"Received error barcode data {errorBarcodes}");
                return errorBarcodes.Count == 0 ?
                    new ErrorBarcodeDetailResponse { status = "true", message = "No record found", data = new List<BarcodeErrorDetail>() }
                    : new ErrorBarcodeDetailResponse { status = "true", message = string.Empty, data = errorBarcodes };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving error barcode data {e.StackTrace}");
                return new ErrorBarcodeDetailResponse { status = "false", message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for Check barcode exist
        /// </summary>
        [HttpPost]
        [Route("CheckBarcodeExist/{barcodeNo}")]
        public async Task<IActionResult> Checkbarcode(string barcodeNo)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var sample = await _supportService.CheckbarcodeExist(barcodeNo);
            return Ok(new CheckBarcodeResponse
            {
                status = sample.status,
                message = sample.message,
                barcodeExist = sample.barcodeExist,
                barcodeValid = sample.barcodeValid,
                data = sample.data
            });
        }

        /// <summary>
        /// Used for Update the Error Barcode into Revised Barcode
        /// </summary>
        [HttpPost]
        [Route("UpdateBarcodeError")]
        public async Task<IActionResult> UpdateErrorBarcode(UpdateBarcodeRequest bData)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Updating the Error Barcode - {JsonConvert.SerializeObject(bData)}");
            var subjectSample = await _supportService.UpdateErrorBarcode(bData);
            return Ok(new ServiceResponse
            {
                Status = subjectSample.Status,
                Message = subjectSample.Message,
            });
        }

        /// <summary>
        /// Used for fetch the  detail for RCH ID error correction
        /// </summary>

        [HttpGet]
        [Route("RetrieveDetailsForRCHIdErrorCorrection/{rchId}")]
        public ErrorBarcodeDetailResponse FetchDetailForRCHIdCorrection(string rchId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorRCHId = _supportService.FetchDetailsForRCHCorrection(rchId);

                _logger.LogInformation($"Received error rch id data {errorRCHId}");
                return errorRCHId.Count == 0 ?
                    new ErrorBarcodeDetailResponse { status = "true", message = "No record found", data = new List<BarcodeErrorDetail>() }
                    : new ErrorBarcodeDetailResponse { status = "true", message = string.Empty, data = errorRCHId };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving rch id error data {e.StackTrace}");
                return new ErrorBarcodeDetailResponse { status = "false", message = e.Message, data = null };
            }
        }


        /// <summary>
        /// Used for Check rchId exist
        /// </summary>
        [HttpPost]
        [Route("CheckRCHIDExist/{rchId}")]
        public async Task<IActionResult> CheckRchId(string rchId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var sample = await _supportService.CheckRCHIDExist(rchId);
            return Ok(new CheckRCHResponse
            {
                status = sample.status,
                message = sample.message,
                rchExist = sample.rchExist,
                rchValid = sample.rchValid,
                data = sample.data
            });
        }

        /// <summary>
        /// Used for Update the RCH ID into Revised RCHID
        /// </summary>
        [HttpPost]
        [Route("UpdateRCHIDError")]
        public async Task<IActionResult> UpdateErrorRCHID(UpdateRCHIDRequest rData)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Updating the Error RCHID - {JsonConvert.SerializeObject(rData)}");
            var subjectSample = await _supportService.UpdateRCHId(rData);
            return Ok(new ServiceResponse
            {
                Status = subjectSample.Status,
                Message = subjectSample.Message,
            });
        }


        /// <summary>
        /// Used for fetch the  detail for LMP error correction
        /// </summary>

        [HttpPost]
        [Route("RetrieveDetailsForLMPErrorCorrection")]
        public ErrorBarcodeDetailResponse FetchDetailForLMPCorrection(FetchRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorLMP = _supportService.FetchDetailsForLMPCorrection(rData);

                _logger.LogInformation($"Received error LMP data {errorLMP}");
                return errorLMP.Count == 0 ?
                    new ErrorBarcodeDetailResponse { status = "true", message = "No record found", data = new List<BarcodeErrorDetail>() }
                    : new ErrorBarcodeDetailResponse { status = "true", message = string.Empty, data = errorLMP };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving LMP error data {e.StackTrace}");
                return new ErrorBarcodeDetailResponse { status = "false", message = e.Message, data = null };
            }
        }


        /// <summary>
        /// Used for Update the Old LMP into Revised LMP
        /// </summary>
        [HttpPost]
        [Route("UpdateLMP")]
        public async Task<IActionResult> UpdateLMP(UpdateLMPRequest rData)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Updating the LMP - {JsonConvert.SerializeObject(rData)}");
            var subjectSample = await _supportService.UpdateLMP(rData);
            return Ok(new ServiceResponse
            {
                Status = subjectSample.Status,
                Message = subjectSample.Message,
            });
        }

        /// <summary>
        /// Used for fetch the  detail for SST error correction
        /// </summary>

        [HttpPost]
        [Route("RetrieveDetailsForSSTCorrection")]
        public ErrorSSTDetailResponse RetrieveDetailsForSSTCorrection(FetchRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorSST = _supportService.FetchDetailsForSSTCorrection(rData);

                _logger.LogInformation($"Received error sst  data {errorSST}");
                return errorSST.Count == 0 ?
                    new ErrorSSTDetailResponse { status = "true", message = "No record found", data = new List<SSTErrorDetail>() }
                    : new ErrorSSTDetailResponse { status = "true", message = string.Empty, data = errorSST };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving sst error data {e.StackTrace}");
                return new ErrorSSTDetailResponse { status = "false", message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for Update the Old SST into Revised SST
        /// </summary>
        [HttpPost]
        [Route("UpdateSST")]
        public async Task<IActionResult> UpdateSST(UpdateSSTRequest rData)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Updating the SST - {JsonConvert.SerializeObject(rData)}");
            var subjectSample = await _supportService.UpdateSST(rData);
            return Ok(new ServiceResponse
            {
                Status = subjectSample.Status,
                Message = subjectSample.Message,
            });
        }

        /// <summary>
        /// Used for retrieve the error barcode detail report
        /// </summary>
        [HttpPost]
        [Route("RetrieveBarcodeErrorReport")]
        public BarcodeErrorReportResponse RetrieveBarcodeErrorReport(ReportRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorReport = _supportService.FetchBarcodeErrorReport(rData);

                _logger.LogInformation($"Received error barcode report  data {errorReport}");
                return errorReport.Count == 0 ?
                    new BarcodeErrorReportResponse { status = "true", message = "No record found", data = new List<BarcodeErrorReportDetail>() }
                    : new BarcodeErrorReportResponse { status = "true", message = string.Empty, data = errorReport };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving error barcode reportr data {e.StackTrace}");
                return new BarcodeErrorReportResponse { status = "false", message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve the error RCHId detail report
        /// </summary>
        [HttpPost]
        [Route("RetrieveRCHIdErrorReport")]
        public RCHErrorReportResponse RetrieveRCHIdErrorReport(ReportRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorReport = _supportService.FetchRCHErrorReport(rData);

                _logger.LogInformation($"Received error rchid report  data {errorReport}");
                return errorReport.Count == 0 ?
                    new RCHErrorReportResponse { status = "true", message = "No record found", data = new List<RCHErrorReportDetail>() }
                    : new RCHErrorReportResponse { status = "true", message = string.Empty, data = errorReport };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving error rchid reportr data {e.StackTrace}");
                return new RCHErrorReportResponse { status = "false", message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve the error LMP detail report
        /// </summary>
        [HttpPost]
        [Route("RetrieveLMPErrorReport")]
        public LMPRerrorReportResponse RetrieveLMPErrorReport(ReportRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorReport = _supportService.FetchLMPErrorReport(rData);

                _logger.LogInformation($"Received error lmp report  data {errorReport}");
                return errorReport.Count == 0 ?
                    new LMPRerrorReportResponse { status = "true", message = "No record found", data = new List<LMPErrorReportDetail>() }
                    : new LMPRerrorReportResponse { status = "true", message = string.Empty, data = errorReport };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving error lmp reportr data {e.StackTrace}");
                return new LMPRerrorReportResponse { status = "false", message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve the error SST Rest Result detail report
        /// </summary>
        [HttpPost]
        [Route("RetrieveSSTResultErrorReport")]
        public SSTErrorReportResponse RetrieveSSTResultErrorReport(ReportRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorReport = _supportService.FetchSSTErrorReport(rData);

                _logger.LogInformation($"Received error sst result report  data {errorReport}");
                return errorReport.Count == 0 ?
                    new SSTErrorReportResponse { status = "true", message = "No record found", data = new List<SSTCorrectionReportDetail>() }
                    : new SSTErrorReportResponse { status = "true", message = string.Empty, data = errorReport };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving error sst result reportr data {e.StackTrace}");
                return new SSTErrorReportResponse { status = "false", message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to add New ANM User
        /// </summary>
        [HttpPost]
        [Route("AddNewANMSUser")]
        public async Task<IActionResult> AddANMUser(AddANMRequest aData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request- {JsonConvert.SerializeObject(aData)}");
            var data = await _supportService.AddNewANMUser(aData);
            _logger.LogInformation($"Add new ANM Data {data}");
            _logger.LogDebug($"Response Adding new ANM Data - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddANMResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }



        [HttpPost]
        [Route("UploadCBCHPLCFiles")]
        public async Task<IActionResult> UploadCBCHPLFiles(List<IFormFile> formFiles)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var result = await _supportService.UploadCBCHPLCFiles(formFiles);
            _logger.LogInformation($"Uploaded Files {result}");
            _logger.LogDebug($"Response Uploaded Files - {JsonConvert.SerializeObject(result)}");
            return Ok(new UploadFileResponse
            {
                Status = result.Status,
                Message = result.Message,
                fileCount = result.fileCount,
                data = result.data
            });

        }
    }
}
