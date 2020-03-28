﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface IUserRoleData
    {
        string Add(UserRoleRequest urData);
        List<UserRole> Retrieve(int code);
        List<UserRole> Retrieve();
    }
    public interface IUserRoleDataFactory
    {
        IUserRoleData Create();
    }
    public class UserRoleDataFactory : IUserRoleDataFactory
    {
        public IUserRoleData Create()
        {
            return new UserRoleData();
        }
    }
}
