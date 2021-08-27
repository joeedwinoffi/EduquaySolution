using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Pathologist
{
    public class PathologistReportResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<PathologistReports> data { get; set; }
    }
}
