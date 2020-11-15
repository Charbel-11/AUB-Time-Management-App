using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers {
    public interface ITeamsHandler {
        void CreateTeamRequest(int ConnectionID, string admin, string teamName, string[] members);
        bool RemoveTeamRequest(int teamID);
        bool AddMemberRequest(string userToAdd, int teamID);
        bool RemoveMemberRequest(int teamID, string userToRemove);
        bool ChangeAdminState(int teamID, string username, bool isNowAdmin);
        Team[] GetPersonalTeams(string username);
    }
}
