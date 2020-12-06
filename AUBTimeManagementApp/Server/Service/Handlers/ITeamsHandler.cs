using Server.DataContracts;
using System.Collections.Generic;

namespace Server.Service.Handlers {
    public interface ITeamsHandler {
        // Create a team gievn an admin username and a list of members usernames
        int CreateTeamRequest(string admin, string teamName, List<string> members);

        // Add a member to team with teamID
        void AddMemberRequest(int teamID, string userToAdd);

        // Remove user with username userToRemove from team with teamID
        bool RemoveMemberRequest(int teamID, string userToRemove);

        // Remove team with teamID from the teams storage
        void RemoveTeam(int teamID);

        // Change the state of a user (admin -> member) or (member -> admin)
        bool ChangeAdminState(int teamID, string username, bool isNowAdmin);

        // Get a list of events ids for a team with teamID and filter by priority
        List<int> getFilteredTeamEvents(int teamID, bool low, bool mid, bool high);

        // Get a list of team objects where user with username is a member
        List<Team> GetUserTeams(string username);

        // Get a list of members usernames for a given team with teamID
        List<string> GetTeamMembers(int teamID);
    }
}
