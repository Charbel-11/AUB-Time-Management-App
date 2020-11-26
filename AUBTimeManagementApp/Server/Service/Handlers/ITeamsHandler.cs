using Server.DataContracts;
using System.Collections.Generic;

namespace Server.Service.Handlers {
    public interface ITeamsHandler {
        void CreateTeamRequest(string teamName, string admin, List<string> members);
        bool AddMemberRequest(int ConnectionID, int teamID, string userToAdd);
        bool RemoveMemberRequest(int teamID, string userToRemove);
        bool ChangeAdminState(int teamID, string username, bool isNowAdmin);
        List<Team> GetPersonalTeams(string username);
        List<int> getTeamEvents(int teamID, bool low, bool mid, bool high);
        List<int> getUserTeams(string username);
        List<string> GetTeamUsers(int teamID);
    }
}
