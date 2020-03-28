﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface IRIData
    {
        string Add(RIRequest rdata);
        List<RI> Retreive(int code);
        List<RI> Retreive();
    }
    public interface IRIDataFactory
    {
        IRIData Create();
    }

    public class RIDataFactory : IRIDataFactory
    {
        public IRIData Create()
        {
            return new RIData();
        }
    }
}

