using Server.Service.Handlers;
using System;
using System.Collections.Generic;
using Server.DataContracts;
using Server.Service.ControlBlocks;

namespace Server {
    /// <summary>
    /// Here the server parse the received message and initializes the appropriate handler
    /// </summary>
    class ServerHandleData {
        public delegate void PacketF(int ConnectionID, byte[] Data);    //Signature of functions of type (int, byte[])
        public static Dictionary<int, PacketF> PacketListener;          //Maps functionID -> function; read-only hence thread-safe

        /// <summary>
        /// Maps integers to corresponding functions
        /// </summary>
        public static void InitializePacketListener() {
            PacketListener = new Dictionary<int, PacketF> {
                { (int)ClientPackages.CMsg, HandleMessage },
                { (int)ClientPackages.CLogin, HandleLogin },
                { (int)ClientPackages.CRegister, HandleRegister },
                { (int)ClientPackages.CGetUserTeams, HandleGetUserTeams },
                { (int)ClientPackages.CGetUserSchedule, HandleGetUserSchedule },
                { (int)ClientPackages.CGetTeamSchedule, HandleGetTeamSchedule },
                { (int)ClientPackages.CFilterUserSchedule, HandleFilterUserSchedule },
                { (int)ClientPackages.CFilterTeamSchedule, HandleFilterTeamSchedule },
                { (int)ClientPackages.CCreateTeam, HandleCreateTeam },
                { (int)ClientPackages.CChangeAdminState, HandleChangeAdminState },
                { (int)ClientPackages.CRemoveMember, HandleRemoveMember },
                { (int)ClientPackages.CAddMember, HandleAddMember },
                {(int)ClientPackages.CCreateTeamEvent, HandleCreateTeamEvent},
                {(int)ClientPackages.CCreatePersonalEvent, HandleCreatePersonalEvent },
                {(int)ClientPackages.CGetPersonalEvent, HandleGetPersonalEvent},
                {(int)ClientPackages.CCancelPersonalEvent, HandleCancelPersonalEvent },
                {(int)ClientPackages.CModifyPersonalEvent, HandleModifyPersonalEvent },
                {(int)ClientPackages.CGetUserInvitations, HandleGetUserInvitations },
                {(int)ClientPackages.CAcceptInvitation, HandleAcceptInvitationReply },
                {(int)ClientPackages.CDeclineInvitation, HandleDeclineInvitationReply }
            };
        }

        

        /// <summary>
        /// Makes sure a newly connected user is a valid user of our application
        /// </summary>
        /// <param name="ConnectionID"></param>
        /// <returns></returns>
        public static bool HandleAuth(int ConnectionID) {
            if (ServerTCP.ClientObjects[ConnectionID].bufferH.Length() < 12) {
                ServerTCP.ClientObjects[ConnectionID].CloseConnection();
                return false;
            }

            int len = ServerTCP.ClientObjects[ConnectionID].bufferH.ReadInteger();
            int id1 = ServerTCP.ClientObjects[ConnectionID].bufferH.ReadInteger();
            int id2 = ServerTCP.ClientObjects[ConnectionID].bufferH.ReadInteger();
            if (len == 8 && id1 == 19239485 && id2 == 5680973) {
                ServerTCP.ClientObjects[ConnectionID].authenticated = true;
                Console.WriteLine(ConnectionID + " was successfully authenticated");
                return true;
            }
            else {
                ServerTCP.ClientObjects[ConnectionID].CloseConnection();
                Console.WriteLine(ConnectionID + " is fake");
                return false;
            }
        }

        /// <summary>
        /// Makes sure that we process every byte of every packet received
        /// </summary>
        /// <param name="ConnectionID"></param>
        /// <param name="data"></param>
        /// In case of packets > 4096 bytes, HandleData will be called mutliple times
        /// and only when all the data is here (length>=plength), the loop will be entered
        public static void HandleData(int ConnectionID, byte[] data)        //Static method is fine since each thread has its own stack 
        {
            try {
                //Writing on the console what is received (for debugging)
                
                foreach (byte bb in data) { Console.Write(bb + " "); }
                Console.Write('\n');
                foreach (byte bb in data) { Console.Write((char)bb); }
                Console.Write('\n');

                if (data == null) { Console.WriteLine("No data..."); return; }

                int pLength = 0;    //Packet length
                byte[] buffer = (byte[])data.Clone();   //To avoid shallow copies

                if (!ServerTCP.ClientObjects.ContainsKey(ConnectionID)) { return; }
                if (ServerTCP.ClientObjects[ConnectionID].bufferH == null)
                    ServerTCP.ClientObjects[ConnectionID].bufferH = new BufferHelper();

                ServerTCP.ClientObjects[ConnectionID].bufferH.WriteBytes(buffer);
                if (!ServerTCP.ClientObjects[ConnectionID].authenticated) {
                    bool a = HandleAuth(ConnectionID);
                    if (!a) { return; }
                    if (ServerTCP.ClientObjects[ConnectionID].bufferH.Length() == 0) { return; }
                }

                if (ServerTCP.ClientObjects[ConnectionID].bufferH.Length() < 4) {
                    Console.WriteLine("Buffer is too empty");
                    ServerTCP.ClientObjects[ConnectionID].bufferH.Clear();
                    return;
                }

                if (!ServerTCP.ClientObjects.ContainsKey(ConnectionID)) { return; }
                pLength = ServerTCP.ClientObjects[ConnectionID].bufferH.ReadInteger(false);  //Advances only when the whole packet is here
                while (pLength >= 4 && pLength <= ServerTCP.ClientObjects[ConnectionID].bufferH.Length() - 4)    //-4 since readPos hasn't advanced yet
                {
                    ServerTCP.ClientObjects[ConnectionID].bufferH.ReadInteger();

                    int packageID = ServerTCP.ClientObjects[ConnectionID].bufferH.ReadInteger();
                    pLength -= 4;
                    data = ServerTCP.ClientObjects[ConnectionID].bufferH.ReadBytes(pLength);

                    //Call the appropriate function in case of a correct packageID
                    if (PacketListener.TryGetValue(packageID, out PacketF packet))
                        packet.Invoke(ConnectionID, data);
                    else { Console.WriteLine("Wrong function ID"); pLength = 0; break; }

                    if (!ServerTCP.ClientObjects.ContainsKey(ConnectionID)) { return; }

                    pLength = 0;
                    if (ServerTCP.ClientObjects[ConnectionID].bufferH.Length() >= 4)
                        pLength = ServerTCP.ClientObjects[ConnectionID].bufferH.ReadInteger(false);
                }

                if (pLength < 4 && ServerTCP.ClientObjects.ContainsKey(ConnectionID)) { ServerTCP.ClientObjects[ConnectionID].bufferH.Clear(); }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }


        private static void HandleMessage(int ConnectionID, byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);
            string msg = bufferH.ReadString();
            Console.WriteLine(msg);
            bufferH.Dispose();
        }

        private static void HandleRegister(int ConnectionID, byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            // Read username and password to buffer
            string username = bufferH.ReadString();
            string firstname = bufferH.ReadString();
            string lastName = bufferH.ReadString();
            string password = bufferH.ReadString();
            string confirmPassowrd = bufferH.ReadString();
            string email = bufferH.ReadString();
            int day = bufferH.ReadInteger();
            int month = bufferH.ReadInteger();
            int year = bufferH.ReadInteger();
            DateTime datoOfBirth = new DateTime(year, month, day);

            Console.WriteLine(username + " has joined the party!!!");

            bufferH.Dispose();

            // Call AccountsHandler 
            IAccountsHandler accountHandler = new AccountsHandler();
            int isRegistered = accountHandler.ConfirmRegistration(username, firstname, lastName, email, password, confirmPassowrd, datoOfBirth);

            Console.WriteLine(isRegistered);
            // If account exists notify the front end to change scenes
            ServerTCP.PACKET_SendRegisterReply(ConnectionID, isRegistered);
        }

        //Some client used PACKAGE_Login, we handle it here
        private static void HandleLogin(int ConnectionID, byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            // Read username and password to buffer
            string username = bufferH.ReadString();
            string password = bufferH.ReadString();

            bufferH.Dispose();

            // Call AccountsHandler 
            IAccountsHandler accountsHandler = new AccountsHandler();
            bool isUser = accountsHandler.ConfirmLogIn(username, password);

            if (isUser) {
                Console.WriteLine(username + " just signed in!");
                ServerTCP.ClientObjects[ConnectionID].username = username;
                ServerTCP.UsernameToConnectionID[username] = ConnectionID;
//                accountsHandler.setOnline(username, true);
            }
            else {
                Console.WriteLine("Invalid Username\\Password");
            }

            // If account exists notify the front end to change scenes
            ServerTCP.PACKET_SendLoginReply(ConnectionID, isUser);
        }

        private static void HandleGetUserTeams(int ConnectionID, byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);
            string username = bufferH.ReadString();
            bufferH.Dispose();

            ITeamsHandler teamsHandler = new TeamsHandler();
            List<Team> teams = teamsHandler.GetPersonalTeams(username);
            ServerTCP.PACKET_SendGetUserTeamsReply(ConnectionID, teams);
        }

        private static void HandleGetUserSchedule(int ConnectionID, byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            // Read userID to buffer
            string username = bufferH.ReadString();

            bufferH.Dispose();

            // Get list of events in the schedule
            IEventScheduleConnector _eventScheduleConnector = new EventScheduleConnector();
            List<Event> eventsList = _eventScheduleConnector.GetPersonalSchedule(username);

            Console.WriteLine("Will show " + eventsList.Count.ToString() + "events!");
            ServerTCP.PACKET_SendGetUserScheduleReply(ConnectionID, eventsList);
        }

        private static void HandleGetTeamSchedule(int ConnectionID, byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);
            int teamID = bufferH.ReadInteger();
            bufferH.Dispose();

            // Get list of events in the schedule
            ISchedulesHandler schedulesHandler = new SchedulesHandler();
            List<int> eventIDs = schedulesHandler.GetTeamSchedule(teamID);
            // Get the events from eventIDs list and add them to the events list
            var eventsHandler = new EventsHandler();
            List<Event> eventsList = eventsHandler.GetEventList(eventIDs);
            ServerTCP.PACKET_SendGetTeamScheduleReply(ConnectionID, teamID, eventsList);
        }

        private static void HandleFilterUserSchedule(int ConnectionID, byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            // Read username and required priorities to buffer
            string username = bufferH.ReadString();
            bool low = bufferH.ReadBool();
            bool medium = bufferH.ReadBool();
            bool high = bufferH.ReadBool();

            bufferH.Dispose();

            // Get list of eventIds of events with required priorities in the schedule of the user
            // Get List of events from the events table in the database
            IEventsHandler eventsHandler = new EventsHandler();
            List<int> filteredEventIDs = new List<int>();
            List<Event> filteredEvents = new List<Event>();
            filteredEventIDs = eventsHandler.getFilteredUserEvents(username, low, medium, high);
            filteredEvents = eventsHandler.GetEventList(filteredEventIDs);

            ServerTCP.PACKET_SendGetUserScheduleReply(ConnectionID, filteredEvents);
        }

        private static void HandleFilterTeamSchedule(int ConnectionID, byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            // Read userID to buffer
            int teamID = bufferH.ReadInteger();
            bool low = bufferH.ReadBool();
            bool medium = bufferH.ReadBool();
            bool high = bufferH.ReadBool();

            bufferH.Dispose();

            // Get list of events in the schedule
            ITeamsHandler teamsHandler = new TeamsHandler();
            List<int> filteredEventIDs = teamsHandler.getTeamEvents(teamID, low, medium, high);
            // Get the events from eventIDs list and add them to the events list
            var eventsHandler = new EventsHandler();
            List<Event> eventsList = eventsHandler.GetEventList(filteredEventIDs);
            ServerTCP.PACKET_SendGetUserScheduleReply(ConnectionID, eventsList);
        }

        private static void HandleCreateTeam(int ConnectionID, byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            string teamName = bufferH.ReadString();
            string admin = bufferH.ReadString();
            int numberOfMembers = bufferH.ReadInteger();
            List<string> members = new List<string> ();
            for(int i = 0; i < numberOfMembers; i++) {
                members.Add(bufferH.ReadString());
            }
            members.Add(admin);

            bufferH.Dispose();

            ITeamUsersConnector _teamUsersConnector = new TeamUsersConnector();
            List<string> invalidUsernames = _teamUsersConnector.CreateTeamRequest(admin, teamName, members);
            ServerTCP.PACKET_CreateTeamReply(ConnectionID, true, invalidUsernames);

            List<string> validUsernames = new List<string>();
            foreach (string user in members)
            {
                if (!invalidUsernames.Contains(user))
                {
                    validUsernames.Add(user);
                }
            }

            foreach (string user in validUsernames)
            {
                if (ServerTCP.UsernameToConnectionID.TryGetValue(user, out int cID))
                {
                    ServerTCP.PACKET_NewTeamCreated(cID, teamName, teamName.GetHashCode(), new string[] { admin }, validUsernames.ToArray());
                }            
            }            
        }

        private static void HandleChangeAdminState(int ConnectionID, byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int teamID = bufferH.ReadInteger();
            string username = bufferH.ReadString();
            bool isNowAdmin = bufferH.ReadBool();

            bufferH.Dispose();

            ITeamsHandler teamsHandler = new TeamsHandler();
            teamsHandler.ChangeAdminState(teamID, username, isNowAdmin);
        }

        private static void HandleRemoveMember(int ConnectionID, byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int teamID = bufferH.ReadInteger();
            string username = bufferH.ReadString();

            bufferH.Dispose();

            ITeamsHandler teamsHandler = new TeamsHandler();
            teamsHandler.RemoveMemberRequest(teamID, username);
        }

        private static void HandleAddMember(int ConnectionID, byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int teamID = bufferH.ReadInteger();
            string username = bufferH.ReadString();

            bufferH.Dispose();

            ITeamsHandler teamsHandler = new TeamsHandler();
            teamsHandler.AddMemberRequest(ConnectionID, teamID, username);
        }

        private static void HandleCreateTeamEvent(int ConnectionID, byte[] data)
        {
            Console.WriteLine("Server is adding the team event");

            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int teamID = bufferH.ReadInteger();
            string eventPlanner = bufferH.ReadString();
            string eventName = bufferH.ReadString();
            int eventPriority = bufferH.ReadInteger();
            string eventStart = bufferH.ReadString();
            string eventEnd = bufferH.ReadString();
            

            bufferH.Dispose();

            // Till now we assume that all team members are invited 
            // It's very simple to make create an event that requires the attendance of some of the members
            // if list of attendees is not null --> only invite the members in the list
            // Else invite all
            Event addedEvent = new Event(eventName.GetHashCode(), eventPriority, eventPlanner, eventName, DateTime.Parse(eventStart), DateTime.Parse(eventEnd), true);
            ITeamEventConnector teamEventConnector = new TeamEventConnector();
            teamEventConnector.CreateTeamEvent(teamID, addedEvent);

            ServerTCP.PACKET_CreatePersonalEventReply(ConnectionID, eventName.GetHashCode());
        }

        private static void HandleCreatePersonalEvent(int ConnectionID, byte[] data)
        {
            Console.WriteLine("Server is adding the event");

            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            string username = bufferH.ReadString();
            string eventName = bufferH.ReadString();
            string eventStart = bufferH.ReadString();
            string eventEnd = bufferH.ReadString();
            int eventPriority = bufferH.ReadInteger();

            bufferH.Dispose();

            Event addedEvent = new Event(eventName.GetHashCode(), eventPriority, username, eventName, DateTime.Parse(eventStart), DateTime.Parse(eventEnd));
            IEventScheduleConnector eventScheduleConnector = new EventScheduleConnector();
            eventScheduleConnector.AddPersonalEvent(username, addedEvent);

            ServerTCP.PACKET_CreatePersonalEventReply(ConnectionID, eventName.GetHashCode());
        }

        private static void HandleGetPersonalEvent(int ConnectionID, byte[] data)
        {

            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int eventID = bufferH.ReadInteger();

            bufferH.Dispose();

            IEventScheduleConnector eventScheduleConnector = new EventScheduleConnector();
            eventScheduleConnector.GetPersonalEventInDetail(eventID);

            //ServerTCP.PACKET_SendCreatePersonalEvent(ConnectionID, );
        }
        private static void HandleCancelPersonalEvent(int ConnectionID, byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            string username = bufferH.ReadString();
            int eventID = bufferH.ReadInteger();

            bufferH.Dispose();
            IEventScheduleConnector eventScheduleConnector = new EventScheduleConnector();
            eventScheduleConnector.CancelPersonalEvent(username, eventID);

            // Modify this (returning true is useless here)
            ServerTCP.PACKET_CancelPersonalEvent(ConnectionID, true);
        }

        private static void HandleModifyPersonalEvent(int ConnectionID, byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int eventID = bufferH.ReadInteger();
            string eventName = bufferH.ReadString();
            string start = bufferH.ReadString();
            string end = bufferH.ReadString();
            int priority = bufferH.ReadInteger();
            string plannerUsername = bufferH.ReadString();

            bufferH.Dispose();

            Event updatedEvent = new Event(eventID, priority, plannerUsername, eventName, DateTime.Parse(start), DateTime.Parse(end));

            IEventScheduleConnector _eventScheduleConnector= new EventScheduleConnector();
            _eventScheduleConnector.UpdatePersonalEvent(updatedEvent);

            //ServerTCP.PACKET_CancelPersonalEvent(ConnectionID, true);
        }

        #region Invitations
        private static void HandleGetUserInvitations(int ConnectionID, byte[]data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);
            string username = bufferH.ReadString();
            bufferH.Dispose();

            IInvitationsConnector invitationsConnector = new InvitationConnector();
            List<Invitation> invitations = invitationsConnector.GetInvitationsDetails(username);
            ServerTCP.PACKET_SendGetUserInvitationsReply(ConnectionID, invitations);
        }

        private static void HandleAcceptInvitationReply(int ConnectionID, byte[] Data)
        {
            Console.WriteLine("Server handling accept invitation");

            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(Data);
            string username = bufferH.ReadString();
            int eventID = bufferH.ReadInteger();
            string invitationSender = bufferH.ReadString();
            int teamID = bufferH.ReadInteger();

            IInvitationsConnector invitationsConnector = new InvitationConnector();
            invitationsConnector.AcceptInvitation(username, eventID, teamID, invitationSender);

        }

        private static void HandleDeclineInvitationReply(int ConnectionID, byte[] Data)
        {
            Console.WriteLine("Server handling decline invitation");

            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(Data);
            string username = bufferH.ReadString();
            int eventID = bufferH.ReadInteger();
            string invitationSender = bufferH.ReadString();
            int teamID = bufferH.ReadInteger();

            IInvitationsConnector invitationsConnector = new InvitationConnector();
            invitationsConnector.DeclineInvitation(username, eventID, teamID, invitationSender);

        }
        #endregion
    }
}
