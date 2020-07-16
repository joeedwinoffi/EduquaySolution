﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Services.MobileSubject;
using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.MobileSubject;
using EduquayAPI.Contracts.V1.Request.MobileAppSampleCollection;
using EduquayAPI.Contracts.V1.Request.MobileAppShipment;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class MobileSubjectController : ControllerBase
    {
        private readonly IMobileSubjectService _mobileSubjectService;
        private readonly ILogger<MobileSubjectController> _logger;
        public MobileSubjectController(IMobileSubjectService mobileSubjectService, ILogger<MobileSubjectController> logger)
        {
            _mobileSubjectService = mobileSubjectService;
            _logger = logger;
        }


        [HttpGet]
        [Route("RetrieveSubjectList/{userId}")]
        public async Task<IActionResult> RetrieveSubjectList(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var subRegListResponse = await _mobileSubjectService.RetrieveDetail(userId);

            return Ok(new SubjectResigrationListResponse
            {
                Status = subRegListResponse.Status,
                Message = subRegListResponse.Message,
                SubjectResigrations = subRegListResponse.SubjectResigrations,
                SampleCollections = subRegListResponse.SampleCollections,
                ShipmentLogDetail = subRegListResponse.ShipmentLogDetail,
            });
        }

        [HttpGet]
        [Route("RetrieveNotificationList/{userId}")]
        public async Task<IActionResult> RetrieveNotificationList(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var nlResponse = await _mobileSubjectService.RetrieveNotifications(userId);

            return Ok(new NotificationListResponse
            {
                Status = nlResponse.Status,
                Message = nlResponse.Message,
                DamagedSamples = nlResponse.DamagedSamples,
                TimeoutExpirySamples = nlResponse.TimeoutExpirySamples,
            });
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddMultipleSubjects(AddSubjectRequest subRegData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Register multiple subjects in mobile app- {JsonConvert.SerializeObject(subRegData)}");
            var subRegResponse = await _mobileSubjectService.AddSubjectRegistration(subRegData);

            return Ok(new SubRegSuccessResponse
            {
                Status = subRegResponse.Status,
                Message = subRegResponse.Message,
                SuccessIds = subRegResponse.SuccessIds,
            });

        }

        [HttpPost]
        [Route("AddSampleCollection")]
        public async Task<IActionResult> AddMultipleSamples(SampleCollectRequest ssData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Collect multiple samples in mobile app- {JsonConvert.SerializeObject(ssData)}");
            var sclResponse = await _mobileSubjectService.AddSampleCollection(ssData);

            return Ok(new SampleCollectionListResponse
            {
                Status = sclResponse.Status,
                Message = sclResponse.Message,
                Barcodes = sclResponse.Barcodes,
            });
        }

        [HttpPost]
        [Route("AddShipment")]
        public async Task<IActionResult> AddMultipleShipments(MobileShipmentsRequest msData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Multiple shipments in mobile app- {JsonConvert.SerializeObject(msData)}");
            var sclResponse = await _mobileSubjectService.AddANMShipment(msData);

            return Ok(new ShipmentListResponse
            {
                Status = sclResponse.Status,
                Message = sclResponse.Message,
                ShipmentIds = sclResponse.ShipmentIds,
            });
        }
    }
}
