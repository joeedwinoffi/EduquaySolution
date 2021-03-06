using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;

namespace EduquayAPI.DataLayer
{
    public interface ICasteData
    {
        AddEditMasters Add(CasteRequest cData);
        List<Caste> Retrieve(int code);
        List<Caste> Retrieve();
    }

    public interface ICasteDataFactory
    {
        ICasteData Create();
    }

    public class CasteDataFactory : ICasteDataFactory
    {
        public ICasteData Create()
        {
            return new CasteData();
        }
    }


}
