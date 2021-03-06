using SentinelAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.MolecularLab
{
    public class MolecularLabReceiptResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<MolecularLabReceiptLog> MolecularLabReceipts { get; set; }
    }
    public class MolecularLabReceiptLog
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string labTechnicianName { get; set; }
        public string shipmentDateTime { get; set; }
        public string dateOfShipment { get; set; }
        public string timeOfShipment { get; set; }
        public string molecularLabName { get; set; }
        public string hospitalNameLocation { get; set; }
        public List<MolecularLabReceiptDetail> ReceiptDetail { get; set; }
    }
}
