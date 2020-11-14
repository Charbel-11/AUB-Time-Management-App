using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUBTimeManagementApp;
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
            { (int)ServerPackages.SGetUserScheduleReply, HandleGetUserScheduleReply },
            { (int)ServerPackages.SGetTeamScheduleReply, HandleGetTeamScheduleReply },
            { (int)ServerPackages.SFilterUserScheduleReply, HandleFilterUserScheduleReply },
            { (int)ServerPackages.SFilterTeamScheduleReply, HandleFilterTeamScheduleReply },
            { (int)ServerPackages.SCreateTeamReply, HandleCreateTeamReply },
            { (int)ServerPackages.SNewTeamCreated, HandleNewTeamCreated },
            { (int)ServerPackages.SNewAdminState, HandleNewAdminState }
            };
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
        private static void HandleMessage(byte[] data) {
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
            Client.Instance.GetTeamScheduleReply(n, eventsList);

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

            string teamName = bufferH.ReadString();
            int teamID = bufferH.ReadInteger();
            string admin = bufferH.ReadString();
            int n = bufferH.ReadInteger();
            List<string> members = new List<string>();
            for(int i = 0; i < n; i++) { members.Add(bufferH.ReadString()); }

            bufferH.Dispose();

            Client.Instance.addedToATeam(teamName, teamID, admin, members.ToArray());
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
    }
}
