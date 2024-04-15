using PrintManagement.Application.Payloads.RequestModels.TeamRequests;
using PrintManagement.Application.Payloads.ResponseModels.DataTeam;
using PrintManagement.Application.Payloads.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.InterfaceServices
{
    public interface ITeamService
    {
        Task<ResponseObject<DataResponseTeam>> CreateTeam(Request_CreateTeam request);
        Task<ResponseObject<DataResponseTeam>> UpdateTeam(Request_UpdateTeam request);
        Task<string> DeleteTeam(Guid teamId);
        Task<IQueryable<DataResponseTeam>> GetAllTeams();
        Task<DataResponseTeam> GetTeamById(Guid teamId);
    }
}
