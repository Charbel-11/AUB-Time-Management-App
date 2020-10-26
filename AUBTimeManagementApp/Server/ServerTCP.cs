using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Service.Accounts;

namespace Server {
    /// <summary>
    /// Handles sending messages to a client
    /// </summary>
    class ServerTCP {
        private static TcpListener ServerSocket;    //The server basically
        public static ConcurrentDictionary<int, ClientObject> ClientObjects;

        public static void InitializeServer() {
            InitializeClientObjects();
            InitializeServerSocket();
        }
        /// <summary>
        /// Initializes our client object dictionary
        /// </summary>
        private static void InitializeClientObjects() {
            ClientObjects = new ConcurrentDictionary<int, ClientObject>();
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

        /// <summary>
        /// Sends a string to the user
        /// </summary>
        /// <param name="ConnectionID">Connection ID of the target user</param>
        /// <param name="msg">Message to be sent</param>
        public static void PACKET_SendMessage(int ConnectionID, string msg) {
            BufferHelper buffer = new BufferHelper();
            buffer.WriteInteger((int)ServerPackages.SMsg);
            buffer.WriteString(msg);
            SendDataTo(ConnectionID, buffer.ToArray());
            buffer.Dispose();
        }

        public static void PACKET_SendLoginReply(int ConnectionID, bool isUser) {
            BufferHelper buffer = new BufferHelper();
            buffer.WriteInteger((int)ServerPackages.SLoginReply);

            // Write bool on buffer
            buffer.WriteBool(isUser);

            SendDataTo(ConnectionID, buffer.ToArray());
            buffer.Dispose();
        }

    }
}
