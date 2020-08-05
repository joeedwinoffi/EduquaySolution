﻿using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Pathologist
{
    public interface IPathologistData
    {
        List<HPLCTestDetails> HPLCResultDetail(int centralLabId);
    }

    public interface IPathologistDataFactory
    {
        IPathologistData Create();
    }
    public class PathologistDataFactory : IPathologistDataFactory
    {
        public IPathologistData Create()
        {
            return new PathologistData();
        }
    }
}
