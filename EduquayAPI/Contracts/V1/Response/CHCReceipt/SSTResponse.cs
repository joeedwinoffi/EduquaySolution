﻿using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CHCReceipt
{
    public class SSTResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CBCSSTest> SSTDetail { get; set; }
    }
}
