﻿using My_Transfermarkt_Core.Models.StadiumModels;
using My_Transfermarkt_Infastructure.DataModels;

namespace My_Transfermarkt_Core.Contracts
{
    public interface IStadiumService
    {
        Task CreateStadiumAsync(AddNewStadiumModel stadium);
        Task<List<StadiumViewModel>> AllAvailableStadiums();
        Task<List<Stadium>> GetAllStadiums();
    }
}