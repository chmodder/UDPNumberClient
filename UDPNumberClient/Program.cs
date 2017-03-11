using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDPNumberClient
{
    class Program
    {
        static void Main(string[] args)
        {
            UDPListener theListener = new UDPListener("127.0.0.1",9999);
            Task.Factory.StartNew(() => theListener.StartListening());

            Thread.Sleep(5000);

            theListener.StopListening();
        }
    }
}
