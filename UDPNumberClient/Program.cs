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
            IPAddress ip = IPAddress.Parse("127.0.0.1"); //
            UdpClient udpClient = new UdpClient(9999);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(ip, 9999); //

            while (true)
            {
                Console.WriteLine("\nWaiting for broadcast");

                Byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                string receivedData = Encoding.ASCII.GetString(receiveBytes, 0, receiveBytes.Length);
                Console.WriteLine($"Received a broadcast from {remoteIpEndPoint}");
                Console.WriteLine(receivedData);

                Thread.Sleep(100);
            }

            //udpClient.Close();
        }
    }
}
