using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Pathologist
{
    public class PathologistReports : IFill
    {
        public string subjectId { get; set; }
        public string subjectType { get; set; }
        public string subjectName { get; set; }
        public string ga { get; set; }
        public string barcodeNo { get; set; }
        public string contact { get; set; }
        public string screeningResults { get; set; }
        public string hplcResults { get; set; }
        public string laboratoryDiagnosis { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectId"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.subjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GA"))
                this.ga = Convert.ToString(reader["GA"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcodeNo = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Contact"))
                this.contact = Convert.ToString(reader["Contact"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ScreeningResults"))
                this.screeningResults = Convert.ToString(reader["ScreeningResults"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCResults"))
                this.hplcResults = Convert.ToString(reader["HPLCResults"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LaboratoryDiagnosis"))
                this.laboratoryDiagnosis = Convert.ToString(reader["LaboratoryDiagnosis"]);
        }
    }
}
