using ServerFrameLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            Api api = new Api();
            try
            {
                api.Init(args);
            }
            catch (Exception e)
            {
                Console.WriteLine("Init Fail:{0}",e.ToString());
                api.Exit();
            }

            Thread thread = new Thread(api.Run);
            thread.Start();1

            Console.WriteLine("Server OnReady..");

            while (thread.IsAlive)
            {
                api.ProcessInput();
                Thread.Sleep(1000);
            }
            api.Exit();
        }
    }
}
