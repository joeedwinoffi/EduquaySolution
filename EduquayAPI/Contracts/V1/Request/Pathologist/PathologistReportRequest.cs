using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Pathologist
{
    public class PathologistReportRequest
    {
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public int subjectType { get; set; }
        public int centralLabId { get; set; }
        public int chcId { get; set; }
        public int phcId { get; set; }
        public int anmId { get; set; }
        public int searchSection { get; set; }
        public int status { get; set; }
    }
}
