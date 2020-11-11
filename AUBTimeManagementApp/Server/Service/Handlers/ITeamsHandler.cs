using Server.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Service.Handlers
{
    public interface ITeamsHandler
    {
        void CreateTeamRequest(int ConnectionID, string admin, string teamName, string[] members);
        bool RemoveTeamRequest(int teamID);
        bool AddMemberRequest(string userToAdd, int teamID);
        bool RemoveMemberRequest(string userToRemove, int teamID);
        bool MakeAdminRequest(string newAdmin, int teamID);
        bool RemoveAdminRequest(string oldAdmin, int teamID);
        Team[] GetPersonalTeams(string username);
        bool LeaveTeamRequest(string username, int teamID);
        void ReceiveNewAdminFlag(string newAdmin, int teamID);
        void ReceiveRemoveAdminFlag(string oldAdmin, int teamID);



    }
}
