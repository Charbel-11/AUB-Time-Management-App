using Server.DataContracts;
using System.Collections.Generic;

namespace Server.Service.Handlers {
    public interface ITeamsHandler {
        int CreateTeamRequest(string admin, string teamName, List<string> members);
        void AddMemberRequest(int teamID, string userToAdd);
        bool RemoveMemberRequest(int teamID, string userToRemove);
        void RemoveTeam(int teamID);
        bool ChangeAdminState(int teamID, string username, bool isNowAdmin);
        List<int> getFilteredTeamEvents(int teamID, bool low, bool mid, bool high);
        List<Team> GetUserTeams(string username);
        List<string> GetTeamMembers(int teamID);
    }
}
