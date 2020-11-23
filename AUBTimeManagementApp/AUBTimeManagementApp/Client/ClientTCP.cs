using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AUBTimeManagementApp;
using AUBTimeManagementApp.DataContracts;


namespace AUBTimeManagementApp.Client {
    class ClientTCP {
        private static TcpClient ClientSocket;
        private static NetworkStream myStream;
        private static byte[] receiveBuffer;

        public static void InitializeClientSocket(string address, int port) {
            ClientSocket = new TcpClient();
            ClientSocket.ReceiveBufferSize = 4096;
            ClientSocket.SendBufferSize = 4096;
            receiveBuffer = new byte[4096 * 2]; //*2 because we are sending and receiving data at the same time          
            ClientSocket.BeginConnect(address, port, ClientConnectCallBack, ClientSocket);
        }

        //Is called when we connect with the server
        private static void ClientConnectCallBack(IAsyncResult result) {
            ClientSocket.EndConnect(result);
            ClientSocket.NoDelay = true;
            myStream = ClientSocket.GetStream();
            myStream.BeginRead(receiveBuffer, 0, 4096 * 2, ReceiveCallBack, null);
            Authenticate();
            if (ClientSocket.Connected == false) { return; }
        }
        private static void ReceiveCallBack(IAsyncResult result) {
            if (ClientSocket == null || myStream == null) { return; }
            int readBytes = myStream.EndRead(result);
            if (readBytes <= 0) { return; }

            byte[] newBytes = new byte[readBytes];
            Array.Copy(receiveBuffer, newBytes, readBytes);
            ClientHandleData.HandleData(newBytes);
            if (ClientSocket == null || myStream == null) { return; }
            myStream.BeginRead(receiveBuffer, 0, 4096 * 2, ReceiveCallBack, null);
        }
        public static void SendData(byte[] data) {
            if (!ClientSocket.Connected) {
                ClientSocket.Close();
                throw new Exception();
            }
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((data.GetUpperBound(0) - data.GetLowerBound(0) + 1));
            bufferH.WriteBytes(data);
            byte[] tmp = bufferH.ToArray();
            myStream.Write(tmp, 0, tmp.Length);
            bufferH.Dispose();
        }

        public static void Authenticate() {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger(19239485); bufferH.WriteInteger(5680973);
            ClientTCP.SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_Message(string msg) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CMsg);

            bufferH.WriteString(msg);

            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_Register(string username, string firstName, string lastName, string password, string confirmPassword, string email, DateTime dateOfBirth)
        {
            BufferHelper bufferH = new BufferHelper();
            //Writes the function ID so the server knows this is PACKAGE_Login and handles it accordingly
            bufferH.WriteInteger((int)ClientPackages.CRegister);
            int day = dateOfBirth.Day, month = dateOfBirth.Month, year = dateOfBirth.Year;

            // Write username and password on buffer
            bufferH.WriteString(username);
            bufferH.WriteString(firstName);
            bufferH.WriteString(lastName);
            bufferH.WriteString(password);
            bufferH.WriteString(confirmPassword);
            bufferH.WriteString(email);
            bufferH.WriteInteger(day);
            bufferH.WriteInteger(month);
            bufferH.WriteInteger(year);

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_Login(string username, string password) {
            BufferHelper bufferH = new BufferHelper();
            //Writes the function ID so the server knows this is PACKAGE_Login and handles it accordingly
            bufferH.WriteInteger((int)ClientPackages.CLogin);

            // Write username and password on buffer
            bufferH.WriteString(username);
            bufferH.WriteString(password);

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_CreateEvent(Event _event)
        {
            BufferHelper bufferH = new BufferHelper();
            //Writes the function ID so the server knows this is PACKAGE_Login and handles it accordingly
            bufferH.WriteInteger((int)ClientPackages.CCreatePersonalEvent);

            // Write username and password on buffer

            bufferH.WriteInteger(_event.ID);
            bufferH.WriteString(_event.eventName);
            bufferH.WriteString ((_event.startTime).ToString());
            bufferH.WriteString((_event.endTime).ToString());
            bufferH.WriteString(_event.plannerUsername);
            bufferH.WriteInteger(_event.priority);
            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_GetEventInDetail(int eventId)
        {
            BufferHelper bufferH = new BufferHelper();

            //Writes the function ID so the server knows this is PACKAGE_Login and handles it accordingly
            bufferH.WriteInteger((int)ClientPackages.CGetPersonalEvent);

            // Write username and password on buffer

            bufferH.WriteInteger(eventId);

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();

        }

        public static void PACKET_GetUserTeams(string username) 
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CGetUserTeams);
            bufferH.WriteString(username);
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_GetUserSchedule(string username)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CGetUserSchedule);
            bufferH.WriteString(username);
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_GetTeamSchedule(int teamID)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CGetTeamSchedule);

            // Write teamID on buffer
            bufferH.WriteInteger(teamID);

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_FilterUserSchedule(string username, bool low, bool medium, bool high)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CFilterUserSchedule);
           
            // write username and required priorities on buffer
            bufferH.WriteString(username);
            bufferH.WriteBool(low);
            bufferH.WriteBool(medium);
            bufferH.WriteBool(high);

            // send it to the user
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_FilterTeamSchedule(int teamID, bool low, bool medium, bool high)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CFilterTeamSchedule);

            // write teamID and required priorities on buffer
            bufferH.WriteInteger(teamID);
            bufferH.WriteBool(low);
            bufferH.WriteBool(medium);
            bufferH.WriteBool(high);

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_CreateTeam(string teamName, string admin, string[] members) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CCreateTeam);

            bufferH.WriteString(teamName);
            bufferH.WriteString(admin);
            bufferH.WriteInteger(members.Length);
            
            foreach (string m in members){
                bufferH.WriteString(m);
            }

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_ChangeAdminState(int teamID, string username, bool isNowAdmin) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CChangeAdminState);

            bufferH.WriteInteger(teamID);
            bufferH.WriteString(username);
            bufferH.WriteBool(isNowAdmin);

            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_RemoveMember(int teamID, string username) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CRemoveMember);

            bufferH.WriteInteger(teamID);
            bufferH.WriteString(username);

            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_AddMember(int teamID, string username) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CAddMember);

            bufferH.WriteInteger(teamID);
            bufferH.WriteString(username);

            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void CloseConnection() {
            if (ClientSocket != null)
                ClientSocket.Close();
        }

        public static void PACKET_CreatePersonalEvent(string username, string eventName, int priority, DateTime start, DateTime end)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CCreatePersonalEvent);

            bufferH.WriteString(username);
            bufferH.WriteString(eventName);
            bufferH.WriteString(start.ToString());
            bufferH.WriteString(end.ToString());
            bufferH.WriteInteger(priority);

            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKET_CancelPersonalEvent(string username, int eventID)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CCreatePersonalEvent);

            bufferH.WriteString(username);
            bufferH.WriteInteger(eventID);

            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void Packet_ModifyPersonalEvent(Event updatedEvent)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CCreatePersonalEvent);

            bufferH.WriteInteger(updatedEvent.ID);
            bufferH.WriteString(updatedEvent.eventName);
            bufferH.WriteString(updatedEvent.startTime.ToString());
            bufferH.WriteString(updatedEvent.endTime.ToString());
            bufferH.WriteInteger(updatedEvent.priority);
            bufferH.WriteString(updatedEvent.plannerUsername);

            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }
    }
}
