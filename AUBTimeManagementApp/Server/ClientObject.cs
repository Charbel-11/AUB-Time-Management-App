using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    /// <summary>
    /// Represents each connected client on the server
    /// </summary>
    class ClientObject {
        public TcpClient Socket;
        public NetworkStream myStream;  //Needed to send and receive data between this specific client client and the server
        public byte[] ReceiveBuffer;    //Stores all the information we are sending from the client to the server or from the server to the client
        public BufferHelper bufferH;
        public List<byte[]> BufferList = new List<byte[]>();

        public int ConnectionID;
        public string username;
        public string IP;
        public bool authenticated;
        public bool StopReading = false;

        /// <summary>
        /// Initializes a new client and begin listening to its requests
        /// </summary>
        /// <param name="_Socket"></param>
        /// <param name="_ConnectionID"></param>
        public ClientObject(TcpClient _Socket, int _ConnectionID) {
            if (_Socket == null) return;

            Socket = _Socket;
            ConnectionID = _ConnectionID;

            Socket.NoDelay = true;              //Pipeline packets without ACKs
            
            //Larger sent/receiveed packets are split but smaller packets are sent/received together
            Socket.ReceiveBufferSize = 4096;    
            Socket.SendBufferSize = 4096;

            bufferH = new BufferHelper();
            ReceiveBuffer = new byte[4096];
            myStream = Socket.GetStream();

            StopReading = authenticated = false;
            IP = Socket.Client.RemoteEndPoint.ToString();

            //Starting to listen to the stream
            //Once we receive data, ReceiveCallback is called
            myStream.BeginRead(ReceiveBuffer, 0, Socket.ReceiveBufferSize, ReceiveCallback, null);  

            Console.WriteLine("Connection incoming from {0}", IP);
        }

        /// <summary>
        /// Asynchronous function called when we receive data
        /// </summary>
        /// <param name="result"></param>
        public void ReceiveCallback(IAsyncResult result) {
            if (StopReading) { return; }
            try {
                //Safety checks
                if (Socket == null) { Console.WriteLine("Socket is null"); return; }
                if (myStream == null) { Console.WriteLine("Stream is null"); return; }
                if (result == null) { CloseConnection(); return; }

                int readBytes = myStream.EndRead(result);
                if (readBytes <= 0) //Not getting any data
                {
                    CloseConnection();
                    return;
                }

                byte[] newBytes = new byte[readBytes];
                Array.Copy(ReceiveBuffer, newBytes, readBytes);
                ServerHandleData.HandleData(ConnectionID, newBytes);

                if (ReceiveBuffer == null) { Console.WriteLine("Rec Buff is null"); return; }
                else if (Socket == null) { Console.WriteLine("Socket is null"); return; }
                else if (myStream == null) { Console.WriteLine("Stream is null"); return; }
                myStream.BeginRead(ReceiveBuffer, 0, Socket.ReceiveBufferSize, ReceiveCallback, null);  //In case we need to receive more data
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                if (StopReading) { return; }
                CloseConnection();
            }
        }

        /// <summary>
        /// Closes the connection with this instance of ClientObject
        /// </summary>
        public void CloseConnection() {
            Console.WriteLine("Connection from {0} has been terminated", IP);
            authenticated = false;

            if (bufferH != null) { bufferH.Dispose(); bufferH = null; }
            if (Socket != null) { Socket.Close(); Socket = null; }

            ServerTCP.ClientObjects.TryRemove(ConnectionID, out ClientObject wtv);
            if (username != "") ServerTCP.UsernameToConnectionID.TryRemove(username, out int cId);
        }

        /// <summary>
        /// Checks for connection and send buffered data not sent before
        /// </summary>
        private void CheckForConnection() {
            if (Socket == null) { CloseConnection(); }
            else {
                foreach (byte[] data in BufferList)
                    ServerTCP.SendDataTo(ConnectionID, data);
                BufferList.Clear();
            }
        }
    }
}