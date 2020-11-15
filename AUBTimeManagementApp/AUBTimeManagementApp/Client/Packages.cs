//Should be the same in the server and the client
//S is for server functions, C is for client functions

public enum ServerPackages {
    SMsg,
    SLoginReply,
    SRegisterReply,
    SGetUserTeamsReply,
    SGetUserScheduleReply,
    SGetTeamScheduleReply,
    SFilterUserScheduleReply,
    SFilterTeamScheduleReply,
    SCreateTeamReply,
    SNewTeamCreated,
    SNewAdminState,
    SMemberRemoved,
    SAddMemberReply,
    SMemberAdded
}
public enum ClientPackages {
    CMsg,
    CLogin,
    CRegister,
    CGetUserTeams,
    CGetUserSchedule,
    CGetTeamSchedule,
    CFilterUserSchedule,
    CFilterTeamSchedule,
    CCreateTeam,
    CChangeAdminState,
    CRemoveMember,
    CAddMember
}