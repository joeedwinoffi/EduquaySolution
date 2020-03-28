﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface IDistrictService
    {
        string AddDistrict(DistrictRequest sdata);
        List<District> Retreive(int code);
        List<District> Retreive();
    }
}