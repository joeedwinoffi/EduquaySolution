using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.Pathologist;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Pathologist;
using EduquayAPI.Models.Pathologist;
using EduquayAPI.Services.Pathologist;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class PathologistController : ControllerBase
    {
        private readonly IPathologistService _pathologistService;
        private readonly ILogger<PathologistController> _logger;
        private readonly IConfiguration _config;
        public readonly IHostingEnvironment _hostingEnvironment;

        public PathologistController(IPathologistService pathologistService, ILogger<PathologistController> logger, IHostingEnvironment hostingEnvironment, IConfiguration config)
        {
            _pathologistService = pathologistService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _config = config;
        }

        /// <summary>
        /// Used for get hplc test data which are not update their result
        /// </summary>
        [HttpGet]
        [Route("RetrieveHPLCTestDetail/{centralLabId}")]
        public async Task<IActionResult> GetSampleList(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var subjectList = await _pathologistService.HPLCResultDetail(centralLabId);
            _logger.LogInformation($"Received hplc test details {subjectList}");
            return Ok(new HPLCTestDetailResponse
            {
                Status = subjectList.Status,
                Message = subjectList.Message,
                SubjectDetails = subjectList.SubjectDetails,
            });
        }

        /// <summary>
        /// Used for get for edit  hplc diagnosis data which are not update their result
        /// </summary>
        [HttpGet]
        [Route("RetrieveEditHPLCDiagnosisDetail/{centralLabId}")]
        public async Task<IActionResult> GetdiagnosisList(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var subjectList = await _pathologistService.EditHPLCDiagnosisDetail(centralLabId);
            _logger.LogInformation($"Received hplc diagnosis  details {subjectList}");
            return Ok(new HPLCDiagnosisDetailResponse
            {
                Status = subjectList.Status,
                Message = subjectList.Message,
                SubjectDetails = subjectList.SubjectDetails,
            });
        }

        /// <summary>
        /// Used for get hplc result master 
        /// </summary>
        [HttpGet]
        [Route("HPLCResultMaster")]
        public HPLCResultMasterResponse GetHPLCMaster()
        {
            try
            {
                var hplcResult = _pathologistService.HPLCResult();
                return hplcResult.Count == 0 ? new HPLCResultMasterResponse { Status = "true", Message = "No hplc result master data found", hplcResults = new List<HPLCResult>() }
                : new HPLCResultMasterResponse { Status = "true", Message = string.Empty, hplcResults = hplcResult };
            }
            catch (Exception e)
            {
                return new HPLCResultMasterResponse { Status = "false", Message = e.Message, hplcResults = null };
            }
        }

        /// <summary>
        /// Used for  Add the new sample recollection of subject which are damaged sample or timout expiry sample
        /// </summary>
        [HttpPost]
        [Route("AddHPLCDiagnosisResult")]
        public async Task<IActionResult> AddHPLCDiagnosisResult(AddHPLCDiagnosisResultRequest aData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding hplc diagnosis results data - {JsonConvert.SerializeObject(aData)}");
            var hplcDiagnosis = await _pathologistService.AddHPLCDiagnosisResult(aData);
            return Ok(new ServiceResponse
            {
                Status = hplcDiagnosis.Status,
                Message = hplcDiagnosis.Message,
            });
        }

        /// <summary>
        /// Used for get sample status in  Diagnosis  
        /// </summary>
        [HttpGet]
        [Route("RetrieveDiagnosisSampleStatus")]
        public PathologistSampleStatusResponse GetSampleStatus()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var sampleStatus = _pathologistService.RetrieveSampleStatus();
                return sampleStatus.Count == 0 ? new PathologistSampleStatusResponse { Status = "true", Message = "No subjects found", sampleStatus = new List<PathologistSampleStatus>() }
                : new PathologistSampleStatusResponse { Status = "true", Message = string.Empty, sampleStatus = sampleStatus };
            }
            catch (Exception e)
            {
                return new PathologistSampleStatusResponse { Status = "false", Message = e.Message, sampleStatus = null };
            }
        }

        /// <summary>
        /// Used for get  reports for Pathologist result 
        /// </summary>
        [HttpPost]
        [Route("RetrievePathologistReports")]
        public PathoReportsResponse GetPathologistReports(PathoReportsRequest prData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for Pathologist diagnosis reports  - {JsonConvert.SerializeObject(prData)}");
                var subjects = _pathologistService.RetrivePathologistReports(prData);
                return subjects.Count == 0 ? new PathoReportsResponse { Status = "true", Message = "No subjects found", Subjects = new List<PathoReports>() }
                : new PathoReportsResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new PathoReportsResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Download HPLC Graph  
        /// </summary>

        [HttpGet]
        [Route("DownloadHPLCGraph")]
        public async Task<ActionResult> Download([FromQuery]string fileName)
        {

            if (fileName.ToUpper() == "" || fileName.ToUpper() == null)
            {
                return BadRequest();
            }
            else
            {
                var hplcGraphLocation = _config.GetSection("Graph").GetSection("HPLCGraphFolder").Value;
                IFileProvider provider = new PhysicalFileProvider(_hostingEnvironment.WebRootPath + hplcGraphLocation);
                IFileInfo fileInfo = provider.GetFileInfo(fileName);
                var readStream = fileInfo.CreateReadStream();
                var mimeType = "application/pdf";
                return File(readStream, mimeType, fileName);
            }
        }

        /// <summary>
        /// Used for get for Sr.Patho refered hplc diagnosis data which are not update their result
        /// </summary>
        [HttpGet]
        [Route("RetrieveSrPathoHPLCDiagnosisDetail/{centralLabId}")]
        public async Task<IActionResult> GetSrPathoDiagnosisList(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var subjectList = await _pathologistService.FetchSrPathoHPLCDiagnosisDetail(centralLabId);
            _logger.LogInformation($"Received sr Patho refered hplc diagnosis  details {subjectList}");
            return Ok(new HPLCDiagnosisDetailResponse
            {
                Status = subjectList.Status,
                Message = subjectList.Message,
                SubjectDetails = subjectList.SubjectDetails,
            });
        }

        /// <summary>
        /// Used for get  reports for Pathologist Diagnosis reslt reports 
        /// </summary>
        [HttpPost]
        [Route("RetrievePathologistReportsDetail")]
        public async Task<IActionResult> RetrievePathologistReportsDetails(PathologistReportRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve subject detail for pathologist diagnosis result report- {JsonConvert.SerializeObject(rData)}");
            var reports = await _pathologistService.RetrivePathologistReportsDetail(rData);
            _logger.LogInformation($"Fetch Subjects for pathologist diagnosis result report {reports}");
            return Ok(new PathologistReportResponse
            {
                status = reports.status,
                message = reports.message,
                data = reports.data,
            });
        }

    }
}