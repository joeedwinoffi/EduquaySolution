﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class SampleCollectionService : ISampleCollectionService
    {
        private readonly ISampleCollectionData _sampleCollectionData;

        public SampleCollectionService(ISampleCollectionDataFactory sampleCollectionDataFactory)
        {
            _sampleCollectionData = new SampleCollectionDataFactory().Create();
        }

        public string AddSample(AddSubjectSampleRequest ssData)
        {
            try
            {             
                var result = _sampleCollectionData.AddSample(ssData);
                return string.IsNullOrEmpty(result) ? $"Unable to add samples data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add samples data - {e.Message}";
            }
        }

        public List<SubjectSamples> Retrieve(SubjectSampleRequest ssData)
        {
            var subjectSamples = _sampleCollectionData.Retrieve(ssData);
            return subjectSamples;
        }
    }
}