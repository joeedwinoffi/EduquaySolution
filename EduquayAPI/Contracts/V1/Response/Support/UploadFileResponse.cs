using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Support
{
    public class UploadFileResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public int fileCount { get; set; }
        public List<UploadFiles> data { get; set; }
    }


    public class UploadFiles
    {
        public string fileName { get; set; }
    }
}
