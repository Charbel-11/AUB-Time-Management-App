//Should be the same in the server and the client
//S is for server functions, C is for client functions

public enum ServerPackages {
    SMsg,
    SLoginReply,
    SRegisterReply,
    SGetUserScheduleReply,
    SCreateTeamReply,
    SNewTeamCreated
}
public enum ClientPackages {
    CMsg,
    CLogin,
    CRegister,
    CGetUserSchedule,
    CCreateTeam
}