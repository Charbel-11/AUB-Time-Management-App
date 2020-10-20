using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUBTimeManagementApp;

namespace AUBTimeManagementApp.Client {
    class ClientHandleData {
        private static ByteBuffer ClientBuffer;
        public delegate void PacketF(byte[] Data);
        public static Dictionary<int, PacketF> PacketListener;

        public static void InitializePacketListener() {
            PacketListener = new Dictionary<int, PacketF>
            {
            { (int)ServerPackages.SMsg, HandleMessage },
            { (int)ServerPackages.SLoginReply, HandleLoginReply }
            };
        }

        public static void HandleData(byte[] data) {
            if (data == null) { return; }

            int pLength = 0;    //Packet length
            byte[] buffer = (byte[])data.Clone();   //To avoid shallow copies

            if (ClientBuffer == null) { ClientBuffer = new ByteBuffer(); }

            ClientBuffer.WriteBytes(buffer);
            if (ClientBuffer.Length() < 4)  //Considers previously received data
            {
                ClientBuffer.Clear();
                return;
            }

            pLength = ClientBuffer.ReadInteger(false);      //Doesn't advance before all the packet is here
            while (pLength >= 4 && pLength <= ClientBuffer.Length() - 4) {
                ClientBuffer.ReadInteger();
                int packageID = ClientBuffer.ReadInteger();
                pLength -= 4;
                data = ClientBuffer.ReadBytes(pLength);
                if (PacketListener.TryGetValue(packageID, out PacketF packet))
                    packet.Invoke(data);
                else {
                    //Wrong function ID
                    break; 
                }

                pLength = 0;
                if (ClientBuffer.Length() >= 4)
                    pLength = ClientBuffer.ReadInteger(false);
            }

            if (pLength < 4) { ClientBuffer.Clear(); }
        }
        private static void HandleMessage(byte[] data) {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            string msg = buffer.ReadString();
          
            buffer.Dispose();
        }

        // OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH 

        // Nourhane

        public static void HandleLoginReply(byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);    //Add the byte[] array to our buffer so that we can read from it

            // Read verification result from accounts handler
            bool isUser = buffer.ReadBool();
            string message = buffer.ReadString();
            buffer.Dispose();
//            return new KeyValuePair<bool, string>(isUser, message);
//Function must have this specific signature so it fits in the dictionary PacketListener
        }

        // OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH OH 
    }
}
