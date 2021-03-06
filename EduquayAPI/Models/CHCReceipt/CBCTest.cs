using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CHCReceipt
{
    public class CBCTest : IFill
    {
        public string subjectName { get; set; }
        public string subjectId { get; set; }
        public string rchId { get; set; }
        public string barcodeNo { get; set; }
        public string mcv { get; set; }
        public string rdw { get; set; }
        public string rbc { get; set; }
        public int testedId { get; set; }

        public string sampleDateTime { get; set; }
        public string testedDateTime { get; set; }
        public bool timeoutStatus { get; set; }

        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleDateTime"))
                this.sampleDateTime = Convert.ToString(reader["SampleDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MCV"))
                this.mcv = Convert.ToString(reader["MCV"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RDW"))
                this.rdw = Convert.ToString(reader["RDW"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RBC"))
                this.rbc = Convert.ToString(reader["RBC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestedId"))
                this.testedId = Convert.ToInt32(reader["TestedId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestedDateTime"))
                this.testedDateTime = Convert.ToString(reader["TestedDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TimeOutStatus"))
                this.timeoutStatus = Convert.ToBoolean(reader["TimeOutStatus"]);

        }
    }

}
