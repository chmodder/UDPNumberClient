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
    public class UDPListener
    {
        public IPAddress EndPointIpAddress { get; set; }
        public int EndPointPortNumber { get; set; }
        public int LocalPortNumber { get; set; }
        public bool IsListening { get; set; }

        #region Constructors
        /// <summary>
        /// Creates a UdpListener where Local and EndPoint portnumbers are the same
        /// </summary>
        /// <param name="endPointIpAddress"></param>
        /// <param name="endPointAndLocalPortNumber"></param>
        public UDPListener(string endPointIpAddress, int endPointAndLocalPortNumber)
        {
            //TODO exception handling for parsing - Overload constructor 1
            EndPointIpAddress = IPAddress.Parse(endPointIpAddress);
            EndPointPortNumber = endPointAndLocalPortNumber;
            LocalPortNumber = endPointAndLocalPortNumber;
        }

        /// <summary>
        /// Creates a UdpListener where Local and EndPoint portnumbers are different
        /// </summary>
        /// <param name="endPointIpAddress"></param>
        /// <param name="endPointPortNumber"></param>
        /// <param name="localPortNumber"></param>
        public UDPListener(string endPointIpAddress, int endPointPortNumber, int localPortNumber)
        {
            //TODO exception handling for parsing - Overload constructor 2
            EndPointIpAddress = IPAddress.Parse(endPointIpAddress);
            EndPointPortNumber = endPointPortNumber;
            LocalPortNumber = localPortNumber;
        }
        #endregion

        public void StartListening()
        {
            IsListening = true;
            IPEndPoint remoteIpEndPoint = new IPEndPoint(EndPointIpAddress, EndPointPortNumber);
            UdpClient udpClient = new UdpClient(9999);

            while (IsListening)
            {
                Console.WriteLine("Waiting for broadcast...");

                Byte[] receiveBytes = udpClient.Receive(ref remoteIpEndPoint);
                string receivedData = Encoding.ASCII.GetString(receiveBytes, 0, receiveBytes.Length);
                Console.WriteLine($"Received a broadcast from {remoteIpEndPoint}");
                Console.WriteLine($"Message: {receivedData}\n");

                Thread.Sleep(100);
            }

            udpClient.Close();
        }

        public void StopListening()
        {
            IsListening = false;
        }
    }
}
