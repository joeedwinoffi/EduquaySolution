using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.Reports;
using EduquayAPI.Contracts.V1.Response.Reports;
using EduquayAPI.Services.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;
        private readonly ILogger<ReportsController> _logger;
        public ReportsController(IReportsService reportsService, ILogger<ReportsController> logger)
        {
            _reportsService = reportsService;
            _logger = logger;
        }

        /// <summary>
        /// Used to fetch anw subjects for tracking
        /// </summary>
        [HttpPost]
        [Route("TrackingANWSubject")]
        public async Task<IActionResult> RetrieveANWSubjects(TrackingSubjectRequest tData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Fetch Subjects for Tracking purpose- {JsonConvert.SerializeObject(tData)}");
            var tracking = await _reportsService.RetrieveANWSubjects(tData.uniqueSubjectId);
            _logger.LogInformation($"Fetch ANW Subjects for Tracking purpose {tracking}");
            return Ok(new TrackingANWSubjectResponse
            {
                status = tracking.status,
                message = tracking.message,
                data = tracking.data,
            });
        }

        /// <summary>
        /// Used to fetch non anw subjects for tracking
        /// </summary>
        [HttpPost]
        [Route("TrackingSubject")]
        public async Task<IActionResult> RetrieveSubjectsForTracking(TrackingSubjectRequest tData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Fetch Subjects for Tracking purpose- {JsonConvert.SerializeObject(tData)}");
            var tracking = await _reportsService.RetrieveSubjectsForTracking(tData.uniqueSubjectId);
            _logger.LogInformation($"Fetch Subjects for Tracking purpose {tracking}");
            return Ok(new TrackingSubjectResponse
            {
                status = tracking.status,
                message = tracking.message,
                data = tracking.data,
            });
        }

        /// <summary>
        /// Used to fetch subjects detail for nhm reports
        /// </summary>
        [HttpPost]
        [Route("NHMReports")]
        public async Task<IActionResult> RetrieveSubjectsForNHMReports(NHMRequest nhmData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve subject detail for nhm report- {JsonConvert.SerializeObject(nhmData)}");
            var nhmReports = await _reportsService.RetriveNHMReportsDetail(nhmData);
            _logger.LogInformation($"Fetch Subjects for nhm reports {nhmReports}");
            return Ok(new NHMReportResponse
            {
                status = nhmReports.status,
                message = nhmReports.message,
                data = nhmReports.data,
            });
        }

    }
}