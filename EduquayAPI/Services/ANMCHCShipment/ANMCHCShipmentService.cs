﻿using EduquayAPI.Contracts.V1.Request.ANMCHCShipment;
using EduquayAPI.DataLayer.ANMCHCShipment;
using EduquayAPI.Models.ANMCHCShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMCHCShipment
{
    public class ANMCHCShipmentService : IANMCHCShipmentService
    {
        private readonly IANMCHCShipmentData _anmchcShipmentData;

        public ANMCHCShipmentService(IANMCHCShipmentDataFactory anmchcShipmentDataFactory)
        {
            _anmchcShipmentData = new ANMCHCShipmentDataFactory().Create();
        }

        public string AddANMCHCShipment(AddANMCHCShipmentRequest asData)
        {
            try
            {
                if (asData.SubjectID <= 0)
                {
                    return "Invalid Subject Id";
                }
                if (string.IsNullOrEmpty(asData.UniqueSubjectID))
                {
                    return "Invalid UniqueSubjectId";
                }
                if (asData.SampleCollectionID <= 0)
                {
                    return "Invalid sample Id";
                }
                if (string.IsNullOrEmpty(asData.ShipmentID))
                {
                    return "Invalid Shipment Id";
                }
                if (asData.ANM_ID <= 0)
                {
                    return "Invalid ANM Id";
                }
                if (asData.TestingCHCID <= 0)
                {
                    return "Invalid Tenting Center  Id";
                }
                if (asData.RIID <= 0)
                {
                    return "Invalid RI  Id";
                }
               
                if (string.IsNullOrEmpty(asData.DateofShipment))
                {
                    return "Invalid Shipment Date";
                }
                if (string.IsNullOrEmpty(asData.TimeofShipment))
                {
                    return "Invalid Shipment Time";
                }

                var result = _anmchcShipmentData.AddANMCHCShipment(asData);
                return string.IsNullOrEmpty(result) ? $"Unable to add  shipment data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add shipment data - {e.Message}";
            }
        }

        public List<ANMCHCShipmentID> ANMCHCGenerateShipmentId(ShipmentIdGenerateRequest sgData)
        {
            var anmchcShipmentID = _anmchcShipmentData.ANMCHCGenerateShipmentId(sgData);
            return anmchcShipmentID;
        }

        public List<ANMCHCShipmentDetail> RetrieveShipmentDetail(ANMCHCShipmentDetailRequest asData)
        {
            var shipmentDetail = _anmchcShipmentData.RetrieveShipmentDetail(asData);
            return shipmentDetail;
        }

        public List<ANMCHCShipmentLogs> RetrieveShipmentLog(ANMCHCShipmentLogRequest asData)
        {
            var shipmentLog = _anmchcShipmentData.RetrieveShipmentLog(asData);
            return shipmentLog;
        }
    }
}
