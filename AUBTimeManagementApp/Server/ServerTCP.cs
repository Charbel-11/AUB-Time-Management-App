using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Service.Handlers;
using Server.DataContracts;
using System.Diagnostics.Eventing.Reader;

namespace Server {
    /// <summary>
    /// Handles sending messages to a client
    /// </summary>
    class ServerTCP {
        private static TcpListener ServerSocket;    //The server basically
        public static ConcurrentDictionary<int, ClientObject> ClientObjects;
        public static ConcurrentDictionary<string, int> UsernameToConnectionID;

        public static void InitializeServer() {
            InitializeClientObjects();
            InitializeServerSocket();
        }
        /// <summary>
        /// Initializes our client object dictionary
        /// </summary>
        private static void InitializeClientObjects() {
            ClientObjects = new ConcurrentDictionary<int, ClientObject>();
            UsernameToConnectionID = new ConcurrentDictionary<string, int>();
        }
        /// <summary>
        /// Sets the port and starts listening to new connections
        /// </summary>
        private static void InitializeServerSocket() {
            ServerSocket = new TcpListener(IPAddress.Any, 8020);
            ServerSocket.Start();
            ServerSocket.BeginAcceptTcpClient(ClientConnectCallback, null); //Once we get a connection, ClientConnectCallback is called
        }

        /// <summary>
        /// Executes once a connection has been initialized
        /// </summary>
        /// <param name="result"></param>
        private static void ClientConnectCallback(IAsyncResult result) {
            TcpClient tempClient = ServerSocket.EndAcceptTcpClient(result); //Accepts the connection and creates its corresponding TcpClient
            ServerSocket.BeginAcceptTcpClient(ClientConnectCallback, null); //Open the connection again for other players

            Random ran = new Random();
            int curID = ran.Next();     //random signed int
            while (curID == 0 || ClientObjects.ContainsKey(curID)) { curID = ran.Next(); }

            ClientObjects[curID] = new ClientObject(tempClient, curID);
        }

        /// <summary>
        /// Sends data to the client
        /// </summary>
        /// <param name="ConnectionID">Connection ID of the target client</param>
        /// <param name="data">Data to be sent</param>
        public static void SendDataTo(int ConnectionID, byte[] data) {
            if (!ClientObjects.ContainsKey(ConnectionID)) { Console.WriteLine("No such connectionID"); return; }
            if (ClientObjects[ConnectionID].Socket == null) {
                ClientObjects[ConnectionID].BufferList.Add(data);
                return;
            }

            BufferHelper buffer = new BufferHelper();
            //Writes the length of the data first
            buffer.WriteInteger(data.GetUpperBound(0) - data.GetLowerBound(0) + 1);
            buffer.WriteBytes(data);
            byte[] tmp = buffer.ToArray();

            ClientObjects[ConnectionID].myStream.BeginWrite(tmp, 0, tmp.Length, null, null);
            buffer.Dispose();
        }

        public static void PACKET_SendRegisterReply(int ConnectionID, int isRegistered)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SRegisterReply);

            // Write bool on buffer
            bufferH.WriteInteger(isRegistered);

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_SendLoginReply(int ConnectionID, bool isUser) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SLoginReply);

            // Write bool on buffer
            bufferH.WriteBool(isUser);

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_SendGetUserTeamsReply(int ConnectionID, List<Team> teams) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SGetUserTeamsReply);

            int n = teams.Count;
            bufferH.WriteInteger(n);
            for (int i = 0; i < n; i++) {
                bufferH.WriteInteger(teams[i].teamID);
                bufferH.WriteString(teams[i].teamName);
                int nA = teams[i].teamAdmin.Count;
                bufferH.WriteInteger(nA);
                for(int j = 0; j < nA; j++) { bufferH.WriteString(teams[i].teamAdmin[j]); }
                int nM = teams[i].teamMembers.Count;
                bufferH.WriteInteger(nM);
                for (int j = 0; j < nM; j++) { bufferH.WriteString(teams[i].teamMembers[j]); }
            }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_SendGetUserScheduleReply(int ConnectionID, List<Event> eventsList)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SGetUserScheduleReply);
            int n = eventsList.Count;
            bufferH.WriteInteger(n);
            for (int i = 0; i < n; i++)
            {
                bufferH.WriteInteger(eventsList[i].eventID);
                bufferH.WriteString(eventsList[i].plannerUsername);
                bufferH.WriteString(eventsList[i].eventName);
                bufferH.WriteInteger(eventsList[i].priority);
                bufferH.WriteString(eventsList[i].startTime.ToString());
                bufferH.WriteString(eventsList[i].endTime.ToString());
                bufferH.WriteBool(eventsList[i].teamEvent);
            }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_SendGetTeamScheduleReply(int ConnectionID, int teamID, List<Event> eventsList)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SGetTeamScheduleReply);
            bufferH.WriteInteger(teamID);
            bufferH.WriteInteger(eventsList.Count);
            for (int i = 0; i < eventsList.Count; i++)
            {
                bufferH.WriteInteger(eventsList[i].eventID);
                bufferH.WriteString(eventsList[i].plannerUsername);
                bufferH.WriteString(eventsList[i].eventName);
                bufferH.WriteInteger(eventsList[i].priority);
                bufferH.WriteString(eventsList[i].startTime.ToString());
                bufferH.WriteString(eventsList[i].endTime.ToString());
                bufferH.WriteBool(eventsList[i].teamEvent);
            }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_SendFilterUserScheduleReply(int ConnectionID, List<Event> eventsList)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SGetUserScheduleReply);
            int n = eventsList.Count;
            bufferH.WriteInteger(n);
            for (int i = 0; i < n; i++)
            {
                bufferH.WriteInteger(eventsList[i].eventID);
                bufferH.WriteString(eventsList[i].plannerUsername);
                bufferH.WriteString(eventsList[i].eventName);
                bufferH.WriteInteger(eventsList[i].priority);
                bufferH.WriteString(eventsList[i].startTime.ToString());
                bufferH.WriteString(eventsList[i].endTime.ToString());
                bufferH.WriteBool(eventsList[i].teamEvent);
            }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_SendFilterTeamScheduleReply(int ConnectionID, List<Event> eventsList)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SGetUserScheduleReply);
            int n = eventsList.Count;
            bufferH.WriteInteger(n);
            for (int i = 0; i < n; i++)
            {
                bufferH.WriteInteger(eventsList[i].eventID);
                bufferH.WriteString(eventsList[i].plannerUsername);
                bufferH.WriteString(eventsList[i].eventName);
                bufferH.WriteInteger(eventsList[i].priority);
                bufferH.WriteString(eventsList[i].startTime.ToString());
                bufferH.WriteString(eventsList[i].endTime.ToString());
                bufferH.WriteBool(eventsList[i].teamEvent);
            }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        //Used to respond to the user who created the team
        //The user will display a message accordingly, however we still send him a PACKET_NewTeamCreated 
        public static void PACKET_CreateTeamReply(int ConnectionID, bool OK, List<string> invalidUsernames) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SCreateTeamReply);

            bufferH.WriteBool(OK);
            if (OK) {
                bufferH.WriteInteger(invalidUsernames.Count);
                foreach(string m in invalidUsernames) { bufferH.WriteString(m); }
            }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        //Sent to every online user that has been added to a team
        public static void PACKET_NewTeamCreated(int ConnectionID, string teamName, int teamID, string[] admin, string[] members) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SNewTeamCreated);

            bufferH.WriteString(teamName);
            bufferH.WriteInteger(teamID);
            bufferH.WriteInteger(admin.Length);
            foreach (string a in admin) { bufferH.WriteString(a); }
            bufferH.WriteInteger(members.Length);
            foreach (string m in members) { bufferH.WriteString(m); }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_NewAdminState(int ConnectionID, int teamID, string username, bool isNowAdmin) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SNewAdminState);

            bufferH.WriteInteger(teamID);
            bufferH.WriteString(username);
            bufferH.WriteBool(isNowAdmin);

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_MemberRemoved(int ConnectionID, int teamID, string removedMember) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SMemberRemoved);

            bufferH.WriteInteger(teamID);
            bufferH.WriteString(removedMember);

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }
    
        public static void PACKET_AddMemberReply(int ConnectionID, int teamID, bool OK) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SAddMemberReply);
            bufferH.WriteInteger(teamID);
            bufferH.WriteBool(OK);
            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_MemberAdded(int ConnectionID, int teamID, string addedMember) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SMemberAdded);

            bufferH.WriteInteger(teamID);
            bufferH.WriteString(addedMember);

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_CreateUserEventReply(int ConnectionID, KeyValuePair<Event, List<Event>> eventAndConflicts)
		{
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SCreateUserEventReply);

            bufferH.WriteInteger(eventAndConflicts.Key.eventID);
            bufferH.WriteString(eventAndConflicts.Key.plannerUsername);
            bufferH.WriteString(eventAndConflicts.Key.eventName);
            bufferH.WriteInteger(eventAndConflicts.Key.priority);
            bufferH.WriteString(eventAndConflicts.Key.startTime.ToString());
            bufferH.WriteString(eventAndConflicts.Key.endTime.ToString());
            bufferH.WriteBool(eventAndConflicts.Key.teamEvent);
            bufferH.WriteString(eventAndConflicts.Key.Link);

            bufferH.WriteInteger(eventAndConflicts.Value.Count);
            for (int i = 0; i < eventAndConflicts.Value.Count; i++)
            {
                bufferH.WriteInteger(eventAndConflicts.Value[i].eventID);
                bufferH.WriteString(eventAndConflicts.Value[i].plannerUsername);
                bufferH.WriteString(eventAndConflicts.Value[i].eventName);
                bufferH.WriteInteger(eventAndConflicts.Value[i].priority);
                bufferH.WriteString(eventAndConflicts.Value[i].startTime.ToString());
                bufferH.WriteString(eventAndConflicts.Value[i].endTime.ToString());
                bufferH.WriteBool(eventAndConflicts.Value[i].teamEvent);
                bufferH.WriteString(eventAndConflicts.Value[i].Link);
            }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_CancelUserEvent(int ConnectionID, bool isCanceled)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SCancelUserEventReply);

            bufferH.WriteBool(isCanceled);

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_SendGetUserInvitationsReply(int ConnectionID, List<Invitation> invitations, List<Event> eventsList)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SGetUserInvitationsReply);

            int n = invitations.Count;
            bufferH.WriteInteger(n);
            for (int i = 0; i < n; i++)
            {
                // Write event details
                bufferH.WriteInteger(invitations[i].invitationID);
                bufferH.WriteInteger(invitations[i].eventID);
                bufferH.WriteString(eventsList[i].eventName);
                bufferH.WriteString(eventsList[i].plannerUsername);
                bufferH.WriteInteger(eventsList[i].priority);
                bufferH.WriteString(eventsList[i].startTime.ToString());
                bufferH.WriteString(eventsList[i].endTime.ToString());

                // write team id
                bufferH.WriteInteger(invitations[i].teamID);

                // write sender username
                bufferH.WriteString(invitations[i].senderUsername);
            }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }
   
        public static void PACKET_SendMergedSchedule(int ConnectionID, int teamID, double[,] freeTimeFreq) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SSendMergedSchedule);

            int n = freeTimeFreq.GetLength(0), m = freeTimeFreq.GetLength(1);
            bufferH.WriteInteger(teamID);
            bufferH.WriteInteger(n);
            bufferH.WriteInteger(m);
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++) {
                    bufferH.WriteInteger((int)(freeTimeFreq[i, j] * 100000000));
                }

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }


        public static void PACKET_AcceptInvitationReply(int ConnectionID, Event acceptedEvent)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ServerPackages.SAcceptInvitationReply);

            bufferH.WriteInteger(acceptedEvent.eventID);
            bufferH.WriteInteger(acceptedEvent.priority);
            bufferH.WriteString(acceptedEvent.eventName);
            bufferH.WriteString(acceptedEvent.plannerUsername);
            bufferH.WriteString(acceptedEvent.startTime.ToString());
            bufferH.WriteString(acceptedEvent.endTime.ToString());
            bufferH.WriteBool(acceptedEvent.teamEvent);

            SendDataTo(ConnectionID, bufferH.ToArray());
            bufferH.Dispose();
        }
    }
}
