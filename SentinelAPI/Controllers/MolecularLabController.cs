using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SentinelAPI.Contracts.V1.Request.MolecularLab;
using SentinelAPI.Contracts.V1.Response;
using SentinelAPI.Contracts.V1.Response.MolecularLab;
using SentinelAPI.Models.MolecularLab;
using SentinelAPI.Services.MolecularLab;

namespace SentinelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MolecularLabController : ControllerBase
    {
        private readonly IMolecularLabService _molecularLabService;
        private readonly ILogger<MolecularLabController> _logger;
        public MolecularLabController(IMolecularLabService molecularLabService, ILogger<MolecularLabController> logger)
        {
            _molecularLabService = molecularLabService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get shipment list receipt  for processing 
        /// </summary>
        [HttpGet]
        [Route("RetrieveMolecularLabReceipt/{molecularLabId}")]
        public async Task<IActionResult> GetShipmentList(int molecularLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var molecularLabReceiptResponse = await _molecularLabService.RetrieveMolecularLabReceipts(molecularLabId);

            return Ok(new MolecularLabReceiptResponse
            {
                Status = molecularLabReceiptResponse.Status,
                Message = molecularLabReceiptResponse.Message,
                MolecularLabReceipts = molecularLabReceiptResponse.MolecularLabReceipts,
            });
        }

        /// <summary>
        /// Used for add receipt  for processing 
        /// </summary>
        [HttpPost]
        [Route("AddReceivedShipments")]
        public async Task<IActionResult> AddMultipleSamples(AddMolecularLabReceiptRequest mlRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Received shipments to add samples for verification  - {JsonConvert.SerializeObject(mlRequest)}");
            var rsResponse = await _molecularLabService.AddReceivedShipment(mlRequest);

            return Ok(new MolecularReceiptResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

      


        /// <summary>
        /// Used for add to update the molecular test result 
        /// </summary>
        [HttpPost]
        [Route("AddMolecularResult")]
        public async Task<IActionResult> AddMolecularResult(AddMolecularResultRequest mrRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Received samples to update molecular test result - {JsonConvert.SerializeObject(mrRequest)}");
            var rsResponse = await _molecularLabService.AddMolecularResult(mrRequest);

            return Ok(new AddMolecularResultResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
            });
        }

        /// <summary>
        /// Used for get  received samples  for molecular test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveMolecularResultsDetail/{molecularLabId}")]
        public MolecularResultResponse RetrieveMolecularResultsDetail(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular test result  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _molecularLabService.RetriveMolecularTestResultsDetail(molecularLabId);
                return subjects.Count == 0 ? new MolecularResultResponse { Status = "true", Message = "No subjects found", Subjects = new List<MolecularResultsDetail>() }
                : new MolecularResultResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new MolecularResultResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for get  subjects  for molecular reports 
        /// </summary>
        [HttpPost]
        [Route("RetriveMolecularReports")]
        public MolecularReportResponse RetriveMolecularReports(FetchMolecularReportsRequest mrData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular reports   - {JsonConvert.SerializeObject(mrData)}");
                var subjects = _molecularLabService.RetriveMolecularReports(mrData);
                return subjects.Count == 0 ? new MolecularReportResponse { Status = "true", Message = "No subjects found", Subjects = new List<MolecularReportsDetail>() }
                : new MolecularReportResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new MolecularReportResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for get  received samples  for molecular test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveSubjectsForTest/{molecularLabId}")]
        public MolecularLabSubjectResponse RetrieveReceivedSubjects(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular test  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _molecularLabService.RetriveSubjectForMolecularTest(molecularLabId);
                return subjects.Count == 0 ? new MolecularLabSubjectResponse { Status = "true", Message = "No subjects found", Subjects = new List<SubjectDetailsForTest>() }
                : new MolecularLabSubjectResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new MolecularLabSubjectResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }


        /// <summary>
        /// Used for get  received Blood samples  for molecular test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveBloodTestEdit/{molecularLabId}")]
        public FetchMLBloodTestEditCompleteResponse RetrieveBloodSamplesEdit(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular blood test complete  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _molecularLabService.RetriveSubjectForMolecularBloodTestEdit(molecularLabId);
                return subjects.Count == 0 ? new FetchMLBloodTestEditCompleteResponse { Status = "true", Message = "No subjects found", Subjects = new List<MolecularSubjectsForBloodTestStatus>() }
                : new FetchMLBloodTestEditCompleteResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new FetchMLBloodTestEditCompleteResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for get  received Blood samples  for molecular test Complete
        /// </summary>
        [HttpGet]
        [Route("RetrieveBloodTestComplete/{molecularLabId}")]
        public FetchMLBloodTestEditCompleteResponse RetrieveBloodSamplesComplete(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular blood test complete  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _molecularLabService.RetriveSubjectForMolecularBloodTestComplete(molecularLabId);
                return subjects.Count == 0 ? new FetchMLBloodTestEditCompleteResponse { Status = "true", Message = "No subjects found", Subjects = new List<MolecularSubjectsForBloodTestStatus>() }
                : new FetchMLBloodTestEditCompleteResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new FetchMLBloodTestEditCompleteResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for add or update the molecular blood test result 
        /// </summary>
        [HttpPost]
        [Route("AddMolecularBloodTestResult")]
        public async Task<IActionResult> AddMolecularBloodTestResult(AddBloodSampleTestRequest mrRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Blood samples to update molecular test result - {JsonConvert.SerializeObject(mrRequest)}");
            var rsResponse = await _molecularLabService.AddMolecularBloodResult(mrRequest);

            return Ok(new ServiceResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
            });
        }

        /// <summary>
        /// Used for get  subjects for molecular test  reports
        /// </summary>
        [HttpPost]
        [Route("RetrieveSubjectsForTestReports")]
        public MolecularLabTestReportResponse RetrieveSubjectsForTestReports(MolecularLabBloodReportRequest rData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular test reports  - {JsonConvert.SerializeObject(rData)}");
                var subjects = _molecularLabService.RetrieveMolecularTestResultsReport(rData);
                return subjects.Count == 0 ? new MolecularLabTestReportResponse { Status = "true", Message = "No subjects found", data = new List<MolecularLabReport>() }
                : new MolecularLabTestReportResponse { Status = "true", Message = string.Empty, data = subjects };
            }
            catch (Exception e)
            {
                return new MolecularLabTestReportResponse { Status = "false", Message = e.Message, data = null };
            }
        }

    }
}