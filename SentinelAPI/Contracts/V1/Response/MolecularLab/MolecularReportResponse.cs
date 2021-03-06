using SentinelAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.MolecularLab
{
    public class MolecularReportResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<MolecularReportsDetail> Subjects { get; set; }
    }
}
