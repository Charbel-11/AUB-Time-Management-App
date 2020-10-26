using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUBTimeManagementApp;

namespace AUBTimeManagementApp.Client {
    class ClientHandleData {
        private static BufferHelper ClientBufferH;
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

        public static void HandleLoginReply(byte[] data)
        {
            BufferHelper bufferH = new BufferHelper();
            bufferH.WriteBytes(data);    //Add the byte[] array to our buffer helper so that we can parse it

            // Read verification result from accounts handler
            bool isUser = bufferH.ReadBool();
            Client.Instance.logInReply(isUser);

            bufferH.Dispose();
        }
    }
}
