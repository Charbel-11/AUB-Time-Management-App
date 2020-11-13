using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AUBTimeManagementApp;

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

            ClientTCP.PACKAGE_Message("Hi!");

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

        public static void PACKAGE_Message(string msg) {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CMsg);

            bufferH.WriteString(msg);

            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKAGE_Register(string username, string firstName, string lastName, string password, string confirmPassword, string email, DateTime dateOfBirth)
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

        public static void PACKAGE_Login(string username, string password) {
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

        public static void PACKAGE_GetUserSchedule(string userID)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CGetUserSchedule);

            // Write userID on buffer
            bufferH.WriteString(userID);

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }


        public static void PACKAGE_GetTeamSchedule(int teamID)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CGetTeamSchedule);

            // Write userID on buffer
            bufferH.WriteInteger(teamID);

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKAGE_FilterUserSchedule(string UserID, int priority)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CFilterUserSchedule);
            bufferH.WriteInteger(priority);

            // Write userID on buffer
            bufferH.WriteString(UserID);

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKAGE_FilterTeamSchedule(int teamID, int priority)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteInteger((int)ClientPackages.CFilterTeamSchedule);
            bufferH.WriteInteger(priority);

            // Write userID on buffer
            bufferH.WriteInteger(teamID);

            //Sends it to the server
            SendData(bufferH.ToArray());
            bufferH.Dispose();
        }

        public static void PACKAGE_CreateTeam(string teamName, string admin, string[] members) {
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

        public static void CloseConnection() {
            if (ClientSocket != null)
                ClientSocket.Close();
        }
    }
}
