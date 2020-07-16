﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Contracts.V1.Response.CHCReceipt;
using EduquayAPI.Models.CHCReceipt;
using EduquayAPI.Services.CHCReceipt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CHCReceiptProcessingController : ControllerBase
    {
        private readonly ICHCReceiptService _chcReceiptService;
        private readonly ILogger<CHCReceiptProcessingController> _logger;
        public CHCReceiptProcessingController(ICHCReceiptService chcReceiptService, ILogger<CHCReceiptProcessingController> logger)
        {
            _chcReceiptService = chcReceiptService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get shipment list receipt  for processing 
        /// </summary>
        [HttpGet]
        [Route("RetrieveCHCReceipt/{testingCHCId}")]
        public async Task<IActionResult> GetShipmentList(int testingCHCId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var chcReceiptResponse = await _chcReceiptService.RetrieveCHCReceipts(testingCHCId);

            return Ok(new CHCReceiptResponse
            {
                Status = chcReceiptResponse.Status,
                Message = chcReceiptResponse.Message,
                CHCReceipts = chcReceiptResponse.CHCReceipts,
            });
        }

        /// <summary>
        /// Used for add receipt  for processing 
        /// </summary>
        [HttpPost]
        [Route("AddReceivedShipments")]
        public async Task<IActionResult> AddMultipleSamples(AddCHCShipmentReceiptRequest chcSRRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Received shipments to add samples for verification  - {JsonConvert.SerializeObject(chcSRRequest)}");
            var rsResponse = await _chcReceiptService.AddReceivedShipment(chcSRRequest);

            return Ok(new CHCReceivedShipmentResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used for add samples to CBC Test 
        /// </summary>
        [HttpPost]
        [Route("AddCBCTest")]
        public async Task<IActionResult> AddCBCTest(CBCTestAddRequest cbcRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"CBC test for multiple samples - {JsonConvert.SerializeObject(cbcRequest)}");
            var rsResponse = await _chcReceiptService.AddCBCTest(cbcRequest);

            return Ok(new CHCReceivedShipmentResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used for add samples to SS Test 
        /// </summary>
        [HttpPost]
        [Route("AddSSTest")]
        public async Task<IActionResult> AddSSTest(SSTestAddRequest ssRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"SS test for multiple samples - {JsonConvert.SerializeObject(ssRequest)}");
            var rsResponse = await _chcReceiptService.AddSSTest(ssRequest);

            return Ok(new CHCReceivedShipmentResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used to fetch sample  for  CBC Test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveCBC/{testingCHCId}")]
        public CBCResponse GetCBC(int testingCHCId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Test CBC for received samples- {JsonConvert.SerializeObject(testingCHCId)}");
                var cbc = _chcReceiptService.RetrieveCBC(testingCHCId);
                return cbc.Count == 0 ? new CBCResponse { Status = "true", Message = "No sample found", CBCDetail = new List<CBCSSTest>() } : new CBCResponse { Status = "true", Message = string.Empty, CBCDetail = cbc };
            }
            catch (Exception e)
            {
                return new CBCResponse { Status = "false", Message = e.Message, CBCDetail = null };
            }
        }

        /// <summary>
        /// Used to fetch sample  for  SS Test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveSST/{testingCHCId}")]
        public SSTResponse GetSST(int testingCHCId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Test SST for received samples- {JsonConvert.SerializeObject(testingCHCId)}");
                var sst = _chcReceiptService.RetrieveSST(testingCHCId);
                return sst.Count == 0 ? new SSTResponse { Status = "true", Message = "No sample found", SSTDetail = new List<CBCSSTest>() } : new SSTResponse { Status = "true", Message = string.Empty, SSTDetail = sst };
            }
            catch (Exception e)
            {
                return new SSTResponse { Status = "false", Message = e.Message, SSTDetail = null };
            }
        }
    }
}