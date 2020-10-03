﻿using SentinelAPI.Contracts.V1.Request.MolecularLab;
using SentinelAPI.Contracts.V1.Response.MolecularLab;
using SentinelAPI.DataLayer.MolecularLab;
using SentinelAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.MolecularLab
{
    public class MolecularLabService : IMolecularLabService
    {

        private readonly IMolecularLabData _molecularLabReceiptData;

        public MolecularLabService(IMolecularLabDataFactory molecularLabDataFactory)
        {
            _molecularLabReceiptData = new MolecularLabDataFactory().Create();
        }

        public async Task<MolecularReceiptResponse> AddReceivedShipment(AddMolecularLabReceiptRequest mlRequest)
        {
            var rsResponse = new MolecularReceiptResponse();
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            var barcodeNo = "";
            var shipmentId = "";
            try
            {
                foreach (var sample in mlRequest.shipmentReceivedRequest)
                {
                    var slist = new BarcodeSampleDetail();
                    barcodeNo = sample.barcodeNo;
                    shipmentId = sample.shipmentId;
                    _molecularLabReceiptData.AddReceivedShipment(sample);
                    slist.barcodeNo = sample.barcodeNo;
                    barcodes.Add(slist);
                }
                rsResponse.Status = "true";
                rsResponse.Message = barcodes.Count + " Samples received successfully in shipment id: " + shipmentId;
                rsResponse.Barcodes = barcodes;
            }
            catch (Exception e)
            {
                rsResponse.Status = "false";
                rsResponse.Message = "Partially " + barcodes.Count + " samples received successfully, From this (" + barcodeNo + ") onwards not received. " + e.Message;
                rsResponse.Barcodes = barcodes;
            }
            return rsResponse;
        }

        public async Task<MolecularLabReceiptResponse> RetrieveMolecularLabReceipts(int MolecularLabId)
        {
            var molecularLabReceiptDetails = _molecularLabReceiptData.RetrieveMolecularLabReceipts(MolecularLabId);
            var molecularLabReceiptsResponse = new MolecularLabReceiptResponse();
            var molecularLabReceiptLog = new List<MolecularLabReceiptLog>();
            try
            {
                var shipmentId = "";
                foreach (var receipt in molecularLabReceiptDetails.ReceiptLog)
                {
                    var rLog = new MolecularLabReceiptLog();
                    if (shipmentId != receipt.shipmentId)
                    {
                        var receiptDetail = molecularLabReceiptDetails.ReceiptDetail.Where(sd => sd.shipmentId == receipt.id).ToList();
                        rLog.id = receipt.id;
                        rLog.shipmentId = receipt.shipmentId;
                        rLog.shipmentDateTime = receipt.shipmentDateTime;
                        rLog.hospitalNameLocation = receipt.hospitalNameLocation;
                        rLog.labTechnicianName = receipt.labTechnicianName;
                        rLog.molecularLabName = receipt.molecularLabName;
                        rLog.ReceiptDetail = receiptDetail;
                        shipmentId = receipt.shipmentId;
                        molecularLabReceiptLog.Add(rLog);
                    }
                }
                molecularLabReceiptsResponse.MolecularLabReceipts = molecularLabReceiptLog;
                molecularLabReceiptsResponse.Status = "true";
                molecularLabReceiptsResponse.Message = string.Empty;
            }
            catch (Exception e)
            {
                molecularLabReceiptsResponse.Status = "false";
                molecularLabReceiptsResponse.Message = e.Message;
            }
            return molecularLabReceiptsResponse;
        }

        public List<SubjectDetailsForTest> RetriveSubjectForMolecularTest(int molecularLabId)
        {
            var allSubject = _molecularLabReceiptData.RetriveSubjectForMolecularTest(molecularLabId);
            return allSubject;
        }
    }
}
