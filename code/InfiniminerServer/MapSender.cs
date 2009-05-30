using System;
using System.Collections.Generic;
using System.Text;
using Lidgren.Network;
using System.Threading;

namespace Infiniminer
{
    class MapSender
    {
        NetConnection client;
        Thread conn;
        Infiniminer.InfiniminerServer infs;
        Infiniminer.InfiniminerNetServer infsN;
        int MAPSIZE = 64;
        //bool finished = false;
        public bool finished
        {
            get
            {
                return !conn.IsAlive;
            }
        }

        public MapSender(NetConnection nClient, Infiniminer.InfiniminerServer nInfs, Infiniminer.InfiniminerNetServer nInfsN, int nMAPSIZE)
        {
            client = nClient;
            infs = nInfs;
            infsN = nInfsN;
            MAPSIZE = nMAPSIZE;
            //finished = false;
            conn = new Thread(new ThreadStart(this.start));
            conn.Start();
            DateTime started = DateTime.Now;
            TimeSpan diff = DateTime.Now - started;
            while (!conn.IsAlive&&diff.Milliseconds<250) //Hold execution until it starts
            {
                diff = DateTime.Now - started;
            }
        }

        private void start()
        {
            //Debug.Assert(MAPSIZE == 64, "The BlockBulkTransfer message requires a map size of 64.");

            for (byte x = 0; x < MAPSIZE; x++)
            for (byte y = 0; y < MAPSIZE; y += 16)
            {
                NetBuffer msgBuffer = infsN.CreateBuffer();
                msgBuffer.Write((byte)Infiniminer.InfiniminerMessage.BlockBulkTransfer);
                msgBuffer.Write(x);
                msgBuffer.Write(y);
                for (byte dy = 0; dy < 16; dy++)
                    for (byte z = 0; z < MAPSIZE; z++)
                        msgBuffer.Write((byte)(infs.blockList[x, y + dy, z]));
                if (client.Status == NetConnectionStatus.Connected)
                    infsN.SendMessage(msgBuffer, client, NetChannel.ReliableUnordered);
            }
            conn.Abort();
        }

        public void stop()
        {
            conn.Abort();
        }
    }
}
