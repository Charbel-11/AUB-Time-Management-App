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
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((data.GetUpperBound(0) - data.GetLowerBound(0) + 1));
            buffer.WriteBytes(data);
            byte[] tmp = buffer.ToArray();
            myStream.Write(tmp, 0, tmp.Length);
            buffer.Dispose();
        }

        public static void Authenticate() {
            ByteBuffer buf = new ByteBuffer();
            buf.WriteInteger(19239485); buf.WriteInteger(5680973);
            ClientTCP.SendData(buf.ToArray());
            buf.Dispose();
        }

        public static void PACKAGE_Message(string msg) {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ClientPackages.CMsg);
            
            buffer.WriteString(msg);

            SendData(buffer.ToArray());
            buffer.Dispose();
        }

        public static void PACKAGE_Login(string username, string password) {
            ByteBuffer buffer = new ByteBuffer();
            //Writes the function ID so the server knows this is PACKAGE_Login and handles it accordingly
            buffer.WriteInteger((int)ClientPackages.CLogin);

            // Write username and password on buffer
            buffer.WriteString(username);
            buffer.WriteString(password);

            //Sends it to the server
            SendData(buffer.ToArray());
            buffer.Dispose();
        }

        public static void CloseConnection() {
            if (ClientSocket != null)
                ClientSocket.Close();
        }
    }
}
