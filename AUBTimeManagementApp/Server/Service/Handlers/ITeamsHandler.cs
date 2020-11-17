using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers {
    public interface ITeamsHandler {
        void CreateTeamRequest(int ConnectionID, string admin, string teamName, string[] members);
        bool AddMemberRequest(int ConnectionID, int teamID, string userToAdd);
        bool RemoveMemberRequest(int teamID, string userToRemove);
        bool ChangeAdminState(int teamID, string username, bool isNowAdmin);
        List<Team> GetPersonalTeams(string username);
        List<int> getTeamEvents(int teamID, bool low, bool mid, bool high);
    }
}
