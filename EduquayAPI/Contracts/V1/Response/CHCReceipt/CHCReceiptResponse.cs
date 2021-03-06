using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CHCReceipt
{
    public class CHCReceiptResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CHCReceiptLog> CHCReceipts { get; set; }
    }

    public class CHCReceiptLog
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string senderName { get; set; }
        public string sendingLocation { get; set; }
        public string shipmentDateTime { get; set; }
        public string riPoint { get; set; }
        public string ilrPoint { get; set; }
        public int shipmentFromId { get; set; }
        public string shipmentFrom { get; set; }
        public string collectionCHC { get; set; }
        public string testingCHC { get; set; }
        public List<CHCReceiptDetail> ReceiptDetail { get; set; }
    }
}
