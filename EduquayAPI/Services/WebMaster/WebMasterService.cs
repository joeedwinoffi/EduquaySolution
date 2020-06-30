﻿using EduquayAPI.DataLayer.WebMaster;
using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.WebMaster
{
    public class WebMasterService : IWebMasterService
    {

        private readonly IWebMasterData _webMasterData;

        public WebMasterService(IWebMasterDataFactory webMasterDataFactory)
        {
            _webMasterData = new WebMasterDataFactory().Create();
        }

        public List<LoadAssociatedANM> RetrieveAssociatedANM(int riId)
        {
            var allANM = _webMasterData.RetrieveAssociatedANM(riId);
            return allANM;
        }

        public List<LoadCaste> RetrieveCaste()
        {
            var allCastes = _webMasterData.RetrieveCaste();
            return allCastes;
        }

        public List<LoadCHCs> RetrieveCHC(int userId)
        {
            var chc = _webMasterData.RetrieveCHC(userId);
            return chc;
        }

        public List<LoadCommunity> RetrieveCommunity(int id)
        {
            var community = _webMasterData.RetrieveCommunity(id);
            return community;
        }

        public List<LoadCommunity> RetrieveCommunity()
        {
            var allCommunity = _webMasterData.RetrieveCommunity();
            return allCommunity;
        }

        public List<LoadConstantValues> RetrieveConstantValues(int userId)
        {
            var allConstant = _webMasterData.RetrieveConstantValues(userId);
            return allConstant;
        }

        public List<LoadDistricts> RetrieveDistrict(int userId)
        {
            var district = _webMasterData.RetrieveDistrict(userId);
            return district;
        }

        public List<LoadGovIDType> RetrieveGovIDType()
        {
            var allGovIDType = _webMasterData.RetrieveGovIDType();
            return allGovIDType;
        }

        public List<LoadILR> RetrieveILR(int riId)
        {
            var allILR = _webMasterData.RetrieveILR(riId);
            return allILR;
        }

        public List<LoadCHCs> RetrieveTestingCHC(int riId)
        {
            var allTestingCHC = _webMasterData.RetrieveTestingCHC(riId);
            return allTestingCHC;
        }

        public List<LoadReligion> RetrieveReligion()
        {
            var allReligion = _webMasterData.RetrieveReligion();
            return allReligion;
        }

        public List<LoadRIs> RetrieveRI(int userId)
        {
            var ri = _webMasterData.RetrieveRI(userId);
            return ri;
        }

        public List<LoadAVD> RetrieveAVD(int riId)
        {
            var allAVD = _webMasterData.RetrieveAVD(riId);
            return allAVD;
        }

        public List<LoadPHCs> RetrievePHC(int userId)
        {
            var allPHC = _webMasterData.RetrievePHC(userId);
            return allPHC;
        }

        public List<LoadSCs> RetrieveSC(int userId)
        {
            var allSC = _webMasterData.RetrieveSC(userId);
            return allSC;
        }
    }
}
