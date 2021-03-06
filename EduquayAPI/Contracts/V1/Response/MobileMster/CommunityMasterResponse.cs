using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileMster
{
    public class CommunityMasterResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<LoadCommunity> Community { get; set; }
    }
}
