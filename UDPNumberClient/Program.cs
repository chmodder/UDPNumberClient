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
            UDPListener theListener = new UDPListener(9999);

            theListener.StartListening();


            ////Starts the listener in a new thread to be able to stop it. 
            ////Else the program will stay in an endless loop inside the StartListening() method
            //Task.Factory.StartNew(() => theListener.StartListening());

            ////Sets the amount of time for the listener to listen before invkong the StopListening method
            ////this is to prevent that the program ends before receiving anything
            //Thread.Sleep(5000);

            //////Stops the listener
            ////theListener.StopListening();
        }
    }
}
