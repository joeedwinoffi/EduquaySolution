﻿using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.WebMaster
{
    public interface IWebMasterService
    {
        List<LoadState> RetrieveState();
        List<LoadDistricts> RetrieveDistrict(int userId);
        List<LoadCHCs> RetrieveCHC(int userId);
        List<LoadPHCs> RetrievePHC(int userId);
        List<LoadSCs> RetrieveSC(int userId);
        List<LoadRIs> RetrieveRI(int userId);
        List<LoadReligion> RetrieveReligion();
        List<LoadCaste> RetrieveCaste();
        List<LoadCommunity> RetrieveCommunity(int id);
        List<LoadCommunity> RetrieveCommunity();
        List<LoadGovIDType> RetrieveGovIDType();
        List<LoadAssociatedANM > RetrieveAssociatedANM(int riId);
        List<LoadConstantValues> RetrieveConstantValues(int userId);
        List<LoadILR> RetrieveILR(int riId);
        List<LoadCHCs> RetrieveTestingCHC(int riId);
        List<LoadCHCs> RetrieveTestingCHCbyCHC(int chcId);
        List<LoadAVD> RetrieveAVD(int riId);
        List<AssociatedSCRIANM> RetrieveAssociatedANMByCHC(int chcId);
        List<LoadLogisticsProvider> RetrieveLogisticsProvider();
        List<LoadCentralLab> RetrieveCentralLabbyCHC(int chcId);
        List<LoadMolecularLab> RetrieveMolecularLabbyCentralLab(int centralLabId);
        List<LoadMolecularResult> RetrieveMolecularResult();
        List<LoadCHCs> RetrieveCHCbyTestingCHC(int testingCHCId);
        List<LoadCHCs> RetrieveCHCbyCentralLab(int centralLabId);
        List<LoadCommon> RetrieveBlocksByDistrict(int id);
        List<LoadCommon> RetrieveCHCByBlock(int id);
        List<LoadCommon> RetrieveANMByCHC(int id);
        List<LoadCommon> RetrieveRIByCHC(int id);
        List<LoadCommon> RetrievePHCByCHC(int id);
    }
}
