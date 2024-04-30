﻿using My_Transfermarkt_Core.Models.MatchModels;
using My_Transfermarkt_Core.Models.TournamentModels;
using My_Transfermarkt_Infastructure.DataModels;

namespace My_Transfermarkt_Core.Contracts
{
    public interface ITournamentService
    {
        Task<List<ShowTournamentModel>> GetAllTournaments();
        Task<string> GetName(int id);
        Task AddTeamToTournament(int tournamentiD, int teamId);
        Task<Tournament> FindTournament(int toiurnamentId);
        Task<TournamentViewModel> GetDetails(int tournamentId);
        Task<bool> IsTeamInTournament(int tournamentId, int teamId);
        Task<Tournament> CheckIfTournamentIsIn(string tournamentName);
        Task AddNewTournamentAsync(Object tournament);
        Task SaveChangesAsync(EditTournamentModel model);
        Task RemoveFromTournament(int tournamentiD, int teamId);
        Task<List<ShowMatchModel>> FindMatchesInTournament(int tourneyId);
        Task <bool> IsItGroupStageTournament(int tourId);
        Task RemoveFromGroup(int tournamentId, int teamId);
    }
}
