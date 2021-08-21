using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CHCReceipt
{
    public class CHCReceiptReportDetails:IFill
    {
        public string anmId { get; set; }
        public string anmName { get; set; }
        public string anmContact { get; set; }
        public string subjectId { get; set; }
        public string subjectType { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public string barcodeNo { get; set; }
        public string timeoutDamaged { get; set; }
        public string shipmentDateTime { get; set; }
        public string shipmentReceivedDate { get; set; }
        public string shipmentId { get; set; }
        public string testDateTime { get; set; }
        public string testResult { get; set; }
        public string chcShipmentDateTime { get; set; }
        public string chcShipmentId { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMId"))
                this.anmId = Convert.ToString(reader["ANMId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMContact"))
                this.anmContact = Convert.ToString(reader["ANMContact"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectId"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.subjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcodeNo = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TimeoutDamaged"))
                this.timeoutDamaged = Convert.ToString(reader["TimeoutDamaged"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentDateTime"))
                this.shipmentDateTime = Convert.ToString(reader["ShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentId"))
                this.shipmentId = Convert.ToString(reader["ShipmentId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentReceivedDate"))
                this.shipmentReceivedDate = Convert.ToString(reader["ShipmentReceivedDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestDateTime"))
                this.testDateTime = Convert.ToString(reader["TestDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestResult"))
                this.testResult = Convert.ToString(reader["TestResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCShipmentDateTime"))
                this.chcShipmentDateTime = Convert.ToString(reader["CHCShipmentDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCShipmentId"))
                this.chcShipmentId = Convert.ToString(reader["CHCShipmentId"]);

        }
    }
}
