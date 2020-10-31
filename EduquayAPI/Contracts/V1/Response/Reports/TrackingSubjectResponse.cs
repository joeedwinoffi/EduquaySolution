﻿using EduquayAPI.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Reports
{
    public class TrackingSubjectResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public TrackingSubjects data { get; set; }
    }
}
