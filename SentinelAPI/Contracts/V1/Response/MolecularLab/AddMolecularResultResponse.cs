using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.MolecularLab
{
    public class AddMolecularResultResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string Result { get; set; }
    }
}
