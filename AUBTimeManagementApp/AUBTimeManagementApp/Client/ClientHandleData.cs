using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUBTimeManagementApp;

namespace AUBTimeManagementApp.Client {
    class ClientHandleData {
        private static ByteBuffer PlayerBuffer;
        public delegate void PacketF(byte[] Data);
        public static Dictionary<int, PacketF> PacketListener;

        public static void InitializePacketListener() {
            PacketListener = new Dictionary<int, PacketF>
            {
            { (int)ServerPackages.SMsg, HandleMessage }
            };
        }

        public static void HandleData(byte[] data) {
            if (data == null) { return; }

            int pLength = 0;    //Packet length
            byte[] buffer = (byte[])data.Clone();   //To avoid shallow copies

            if (PlayerBuffer == null) { PlayerBuffer = new ByteBuffer(); }

            PlayerBuffer.WriteBytes(buffer);
            if (PlayerBuffer.Length() < 4)  //Considers previously received data
            {
                PlayerBuffer.Clear();
                return;
            }

            pLength = PlayerBuffer.ReadInteger(false);      //Doesn't advance before all the packet is here
            while (pLength >= 4 && pLength <= PlayerBuffer.Length() - 4) {
                PlayerBuffer.ReadInteger();
                int packageID = PlayerBuffer.ReadInteger();
                pLength -= 4;
                data = PlayerBuffer.ReadBytes(pLength);
                if (PacketListener.TryGetValue(packageID, out PacketF packet))
                    packet.Invoke(data);
                else {
                    //Wrong function ID
                    break; 
                }

                pLength = 0;
                if (PlayerBuffer.Length() >= 4)
                    pLength = PlayerBuffer.ReadInteger(false);
            }

            if (pLength < 4) { PlayerBuffer.Clear(); }
        }
        private static void HandleMessage(byte[] data) {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            string msg = buffer.ReadString();
          
            buffer.Dispose();
        }

        // OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH 

        // Nourhane

        public static KeyValuePair<bool, string> HandleLogin(string username, string password)
        {
            ByteBuffer buffer = new ByteBuffer();

            // Write username and password on buffer
            buffer.WriteString(username);
            buffer.WriteString(password);
        
            // Read verification result from accounts handler
            bool isUser = buffer.ReadBool();

            // Error !!!
            //string message = buffer.ReadString();
            string message = "connected";
            buffer.Dispose();
            return new KeyValuePair<bool, string>(isUser, message);
        }

        // OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH 
    }
}
