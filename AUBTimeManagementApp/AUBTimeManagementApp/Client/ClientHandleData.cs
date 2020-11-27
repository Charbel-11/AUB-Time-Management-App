using System;
using System.Collections.Generic;
using AUBTimeManagementApp.DataContracts;

namespace AUBTimeManagementApp.Client {
    class ClientHandleData {
        private static BufferHelper ClientBufferH;
        public delegate void PacketF(byte[] Data);
        public static Dictionary<int, PacketF> PacketListener;

        public static void InitializePacketListener() {
            PacketListener = new Dictionary<int, PacketF>
            {
            { (int)ServerPackages.SMsg, HandleMessage },
            { (int)ServerPackages.SLoginReply, HandleLoginReply },
            { (int)ServerPackages.SRegisterReply, HandleRegisterReply },
            { (int)ServerPackages.SGetUserTeamsReply, HandleGetUserTeamsReply },
            { (int)ServerPackages.SGetUserScheduleReply, HandleGetUserScheduleReply },
            { (int)ServerPackages.SGetTeamScheduleReply, HandleGetTeamScheduleReply },
            { (int)ServerPackages.SFilterUserScheduleReply, HandleFilterUserScheduleReply },
            { (int)ServerPackages.SFilterTeamScheduleReply, HandleFilterTeamScheduleReply },
            { (int)ServerPackages.SCreateTeamReply, HandleCreateTeamReply },
            { (int)ServerPackages.SNewTeamCreated, HandleNewTeamCreated },
            { (int)ServerPackages.SNewAdminState, HandleNewAdminState },
            { (int)ServerPackages.SMemberRemoved, HandleMemberRemoved },
            { (int)ServerPackages.SAddMemberReply, HandleAddMemberReply },
            { (int)ServerPackages.SMemberAdded, HandleMemberAdded },
                {(int)ServerPackages.SCreateTeamEventReply, HandleCreateTeamReply},
            {(int)ServerPackages.SGetPersonalEventReply, HandleGetPersonalEventReply },
            {(int)ServerPackages.SCreatePersonalEventReply, HandleCreatePersonalEventReply },
                {(int)ServerPackages.SCancelPersonalEventReply, HandleCancelPersonalEventReply},
                {(int) ServerPackages.SGetUserInvitationsReply, HandleGetUserInvitationsReply}
            };
        }

        private static void HandleGetUserInvitationsReply(byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int n = bufferH.ReadInteger(); // n = number of invitations to be read
            List<Invitation> invitations = new List<Invitation>();
            for (int i = 0; i < n; i++)
            {
                // Write event details
                int eventID = bufferH.ReadInteger();
                string eventName = bufferH.ReadString();
                string plannerUsername = bufferH.ReadString();
                int priority = bufferH.ReadInteger();
                DateTime startTime = DateTime.Parse(bufferH.ReadString());
                DateTime endTime = DateTime.Parse(bufferH.ReadString());
                Event _event = new Event(eventID, priority, plannerUsername, eventName, startTime, endTime, true);

                // write team id
                int teamID = bufferH.ReadInteger();

                // write sender username
                string invitationSender = bufferH.ReadString();

                invitations.Add(new Invitation(_event, invitationSender, teamID));
            }

            Client.Instance.GetUserInvitationsReply(invitations);

            bufferH.Dispose();
        }

        private static void HandleCreatePersonalEventReply(byte[] Data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(Data);
            int eventID = bufferH.ReadInteger();
            /*// Read verification result from server
            int isCreated = bufferH.ReadInteger();
            // TODO: Display something to the user*/

            Client.Instance.CreatePersonalEventReply(eventID);
            bufferH.Dispose();
        }

        private static void HandleGetPersonalEventReply(byte[] Data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(Data);

            int eventID = bufferH.ReadInteger();
            string planner = bufferH.ReadString();
            string eventName = bufferH.ReadString();
            int eventPriority = bufferH.ReadInteger();
            string eventStart = bufferH.ReadString();
            string eventEnd = bufferH.ReadString();
            bool isteamEvent = bufferH.ReadBool();
            Event _event = new Event(eventID, eventPriority, planner, eventName, DateTime.Parse(eventStart), DateTime.Parse(eventEnd), isteamEvent);

            Client.Instance.ShowEvent(_event);

            bufferH.Dispose();
        }

        public static void HandleData(byte[] data) {
            if (data == null) { return; }

            int pLength = 0;    //Packet length
            byte[] buffer = (byte[])data.Clone();   //To avoid shallow copies

            if (ClientBufferH == null) { ClientBufferH = new BufferHelper(); }

            ClientBufferH.WriteBytes(buffer);
            if (ClientBufferH.Length() < 4)  //Considers previously received data
            {
                ClientBufferH.Clear();
                return;
            }

            pLength = ClientBufferH.ReadInteger(false);      //Doesn't advance before all the packet is here
            while (pLength >= 4 && pLength <= ClientBufferH.Length() - 4) {
                ClientBufferH.ReadInteger();
                int packageID = ClientBufferH.ReadInteger();
                pLength -= 4;
                data = ClientBufferH.ReadBytes(pLength);
                if (PacketListener.TryGetValue(packageID, out PacketF packet))
                    packet.Invoke(data);
                else {
                    //Wrong function ID
                    break; 
                }

                pLength = 0;
                if (ClientBufferH.Length() >= 4)
                    pLength = ClientBufferH.ReadInteger(false);
            }

            if (pLength < 4) { ClientBufferH.Clear(); }
        }
        public static void HandleMessage(byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);
            string msg = bufferH.ReadString();

            bufferH.Dispose();
        }

        public static void HandleRegisterReply(byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);    //Add the byte[] array to our buffer helper so that we can parse it

            // Read verification result from accounts handler
            int isRegistered = bufferH.ReadInteger();
            Client.Instance.registerReply(isRegistered);

            bufferH.Dispose();
        }

        public static void HandleLoginReply(byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);    //Add the byte[] array to our buffer helper so that we can parse it

            // Read verification result from accounts handler
            bool isUser = bufferH.ReadBool();
            Client.Instance.logInReply(isUser);

            bufferH.Dispose();
        }

        public static void HandleGetUserTeamsReply(byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int n = bufferH.ReadInteger();
            List<Team> teams = new List<Team>();
            for (int i = 0; i < n; i++) {
                int teamID = bufferH.ReadInteger();
                string teamName = bufferH.ReadString();
                Team curTeam = new Team(teamID, teamName);
                
                int nA = bufferH.ReadInteger();
                for(int j = 0; j < nA; j++) { curTeam.addAdmin(bufferH.ReadString()); }
                int nM = bufferH.ReadInteger();
                for(int j = 0; j < nM; j++) { curTeam.addMember(bufferH.ReadString()); }
                teams.Add(curTeam);            
            }
            Client.Instance.GetUserTeamsReply(teams);

            bufferH.Dispose();
        }

        public static void HandleGetUserScheduleReply(byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int n = bufferH.ReadInteger();
            List<Event> eventsList = new List<Event>();
            for (int i = 0; i < n; i++)
            {
                int eventID = bufferH.ReadInteger();
                string planner = bufferH.ReadString();
                string eventName = bufferH.ReadString();
                int eventPriority = bufferH.ReadInteger();
                string eventStart = bufferH.ReadString();
                string eventEnd = bufferH.ReadString();
                bool isteamEvent = bufferH.ReadBool();
                Event curevent = new Event(eventID, eventPriority, planner, eventName, DateTime.Parse(eventStart), DateTime.Parse(eventEnd), isteamEvent);
                eventsList.Add(curevent);
            }
            Client.Instance.GetUserScheduleReply(n, eventsList);

            bufferH.Dispose();
        }

        public static void HandleGetTeamScheduleReply(byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);
            int teamID = bufferH.ReadInteger();
            int n = bufferH.ReadInteger();
            List<Event> eventsList = new List<Event>();
            for (int i = 0; i < n; i++)
            {
                int eventID = bufferH.ReadInteger();
                string planner = bufferH.ReadString();
                string eventName = bufferH.ReadString();
                int eventPriority = bufferH.ReadInteger();
                string eventStart = bufferH.ReadString();
                string eventEnd = bufferH.ReadString();
                bool isteamEvent = bufferH.ReadBool();
                Event curevent = new Event(eventID, eventPriority, planner, eventName, DateTime.Parse(eventStart),DateTime.Parse(eventEnd), isteamEvent);
                eventsList.Add(curevent);
            }
            Client.Instance.GetTeamScheduleReply(teamID, eventsList);

            bufferH.Dispose();
        }

        public static void HandleFilterUserScheduleReply(byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int n = bufferH.ReadInteger();
            List<Event> eventsList = new List<Event>();
            for (int i = 0; i < n; i++)
            {
                int eventID = bufferH.ReadInteger();
                string planner = bufferH.ReadString();
                string eventName = bufferH.ReadString();
                int eventPriority = bufferH.ReadInteger();
                string eventStart = bufferH.ReadString();
                string eventEnd = bufferH.ReadString();
                bool isteamEvent = bufferH.ReadBool();
                Event curevent = new Event(eventID, eventPriority, planner, eventName, DateTime.Parse(eventStart), DateTime.Parse(eventEnd), isteamEvent);
                eventsList.Add(curevent);
            }
            Client.Instance.FilterUserScheduleReply(n, eventsList);

            bufferH.Dispose();
        }

        public static void HandleFilterTeamScheduleReply(byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int n = bufferH.ReadInteger();
            List<Event> eventsList = new List<Event>();
            for (int i = 0; i < n; i++)
            {
                int eventID = bufferH.ReadInteger();
                string planner = bufferH.ReadString();
                string eventName = bufferH.ReadString();
                int eventPriority = bufferH.ReadInteger();
                string eventStart = bufferH.ReadString();
                string eventEnd = bufferH.ReadString();
                bool isteamEvent = bufferH.ReadBool();
                Event curevent = new Event(eventID, eventPriority, planner, eventName, DateTime.Parse(eventStart), DateTime.Parse(eventEnd), isteamEvent);
                eventsList.Add(curevent);
            }
            Client.Instance.FilterTeamScheduleReply(n, eventsList);

            bufferH.Dispose();
        }

        public static void HandleCreateTeamReply(byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            bool OK = bufferH.ReadBool();
            List<string> invalidUsernames = new List<string>();
            if (OK) {
                int n = bufferH.ReadInteger();
                for(int i = 0; i < n; i++) { invalidUsernames.Add(bufferH.ReadString()); }
            }

            bufferH.Dispose();

            Client.Instance.createTeamReply(OK, invalidUsernames.ToArray());
        }

        public static void HandleNewTeamCreated(byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            List<string> members = new List<string>();
            List<string> admins = new List<string>();

            string teamName = bufferH.ReadString();
            int teamID = bufferH.ReadInteger();
            int nA = bufferH.ReadInteger();
            for (int i = 0; i < nA; i++) { admins.Add(bufferH.ReadString()); }
            int n = bufferH.ReadInteger();
            for(int i = 0; i < n; i++) { members.Add(bufferH.ReadString()); }

            bufferH.Dispose();

            Client.Instance.addedToATeam(teamName, teamID, admins, members);
        }

        public static void HandleNewAdminState(byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int teamID = bufferH.ReadInteger();
            string username = bufferH.ReadString();
            bool isNowAdmin = bufferH.ReadBool();

            bufferH.Dispose();

            Client.Instance.adminStateChanged(teamID, username, isNowAdmin);
        }

        public static void HandleMemberRemoved(byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int teamID = bufferH.ReadInteger();
            string removedMember = bufferH.ReadString();

            bufferH.Dispose();

            Client.Instance.memberRemoved(teamID, removedMember);
        }
        
        public static void HandleAddMemberReply(byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);
            int teamID = bufferH.ReadInteger();
            bool OK = bufferH.ReadBool();
            bufferH.Dispose();
            Client.Instance.addMemberReply(teamID, OK);
        }

        public static void HandleMemberAdded(byte[] data) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            int teamID = bufferH.ReadInteger();
            string addedMember = bufferH.ReadString();

            bufferH.Dispose();

            Client.Instance.memberAdded(teamID, addedMember);
        }

        public static void HandleCancelPersonalEventReply(byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);

            bool isCanceled = bufferH.ReadBool();

            bufferH.Dispose();

            Client.Instance.personalEventCanceled(isCanceled);
        }
    }
}
