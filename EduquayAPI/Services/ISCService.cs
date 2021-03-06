using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface ISCService
    {
        Task<AddEditResponse> Add(SCRequest sData);
        List<SC> Retrieve(int code);
        List<SC> Retrieve();
    }
}
