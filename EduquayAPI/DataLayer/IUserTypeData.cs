using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;

namespace EduquayAPI.DataLayer
{
    public interface IUserTypeData
    {
        AddEditMasters Add(UserTypeRequest utData);
        List<UserType> Retrieve(int code);
        List<UserType> Retrieve();
    }
    public interface IUserTypeDataFactory
    {
        IUserTypeData Create();
    }
    public class UserTypeDataFactory : IUserTypeDataFactory
    {
        public IUserTypeData Create()
        {
            return new UserTypeData();
        }
    }
}
