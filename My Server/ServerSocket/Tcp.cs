using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerSocket
{
    public class Tcp
    {
        public bool needListenHeartbeat = true;
        public bool NeedListenHeartbeat
        {
            get { return needListenHeartbeat; }
            set { needListenHeartbeat = value; }
        }

        public string IP { get; set; }

        int offset = 0;
        private byte[] recvstream = new byte[4096];

        public delegate int AsyncReadCallback(MemoryStream stream);
        public delegate void AsyncConnectCallback(bool ret);
        public delegate void AsyncAcceptCallback(bool ret);
        public delegate void AsyncDisconnectCallback();

        private AsyncReadCallback onRead = DefaultOnRead;
        private AsyncConnectCallback onConnect = DefaultOnConnect;
        private AsyncAcceptCallback onAccept = DefaultOnAccept;
        private AsyncDisconnectCallback onDisconnect = DefaultOnDisconnect;

        static private int DefaultOnRead(MemoryStream stream)
        {
            Console.WriteLine("default on read function called,check it!");
            return 0;
        }
        static private void DefaultOnConnect(bool ret)
        {
            Console.WriteLine("default on connect function called,check it!");
        }
        static private void DefaultOnAccept(bool ret)
        {
            Console.WriteLine("default on accept function called,check it!");
        }
        static private void DefaultOnDisconnect()
        {
            Console.WriteLine("default on disconnect function called,check it!");
        }

        public AsyncReadCallback OnRead
        {
            get { return onRead; }
            set { onRead = value; }
        }
        public AsyncConnectCallback OnConnect
        {
            get { return onConnect; }
            set { onConnect = value; }
        }
        public AsyncAcceptCallback OnAccept
        {
            get { return onAccept; }
            set { onAccept = value; }
        }
        public AsyncDisconnectCallback OnDisconnect
        {
            get { return onDisconnect; }
            set { onDisconnect = value; }
        }

        IList<ArraySegment<byte>> sendStreams = new List<ArraySegment<byte>>();
        IList<ArraySegment<byte>> waitStreams = new List<ArraySegment<byte>>();
        public int WaitStreamsCount = 0;

        enum State
        {
            IDLE=0,
            WAIT,
            RUN,
            CLOSE,
        }


        private ushort port = 0;
        private int curState = (int)State.IDLE;

        private Socket socket = null;
        public bool Accept(ushort port)
        {
            if(socket!=null)
            {
                return false;
            }
           //frTODO：
            return true;
        }
    }
}
