using EduquayAPI.Models.PNDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.PNDT
{
    public class PrePNDTCounsellingResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<PrePNDTCounselling> data { get; set; }
    }
}
