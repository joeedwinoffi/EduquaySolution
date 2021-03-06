using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileSubject
{
    public class UpdateReferalStatusResponse
    {
        public string Status { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }
        public List<SubjectIdList> SubjectIds { get; set; }
    }
    public class SubjectIdList
    {
        public string uniqueSubjectId { get; set; }
    }
}
