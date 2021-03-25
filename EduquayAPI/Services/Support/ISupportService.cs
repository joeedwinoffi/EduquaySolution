﻿using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Support;
using EduquayAPI.Models.Support;
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
        Task<ServiceResponse> UpdateRCHId(UpdateRCHIDRequest rData);
        Task<CheckRCHResponse> CheckRCHIDExist(string rchId);
    }
}