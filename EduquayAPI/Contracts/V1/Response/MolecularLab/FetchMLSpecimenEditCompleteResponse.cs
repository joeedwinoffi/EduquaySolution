using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MolecularLab
{
    public class FetchMLSpecimenEditCompleteResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<MLabSpecimenForTestStatus> Subjects { get; set; }
    }
}
