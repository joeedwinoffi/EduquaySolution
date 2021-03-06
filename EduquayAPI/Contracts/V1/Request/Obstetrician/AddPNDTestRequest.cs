using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Obstetrician
{
    public class AddPNDTestRequest
    {
        public int prePNDTCounsellingId { get; set; }
        public string anwsubjectId { get; set; }
        public string spouseSubjectId { get; set; }
        public string pndtDateTime { get; set; }
        public int counsellorId { get; set; }
        public int obstetricianId { get; set; }
        public string clinicalHistory { get; set; }
        public string examination { get; set; }
        public int procedureOfTestingId { get; set; }
        public string othersProcedureofTesting { get; set; }
        public string pndtComplecationsId { get; set; }
        public string othersComplecations { get; set; }
        public int pndtDiagnosisId { get; set; }
        public int pndtResultId { get; set; }
        public string motherVoided { get; set; }
        public string motherVitalStable { get; set; }
        public string foetalHeartRateDocumentScan { get; set; }
        public string planForPregnencyContinue { get; set; }
        public bool isCompletePNDT { get; set; }
        public int userId { get; set; }

    }
}
