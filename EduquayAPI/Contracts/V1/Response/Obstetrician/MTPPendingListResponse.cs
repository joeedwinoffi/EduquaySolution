using EduquayAPI.Models.MTPObstetrician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Obstetrician
{
    public class MTPPendingListResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<MTPPending> data { get; set; }
    }
}
