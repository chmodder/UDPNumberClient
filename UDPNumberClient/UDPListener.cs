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
        public IPAddress RemoteEPIpAddress { get; set; }
        public int RemoteEPPortNumber { get; set; }
        public bool IsListening { get; set; }

        #region Constructors

        /// <summary>
        /// Creates a UdpListener where Local and EndPoint portnumbers are the same
        /// Uses Any IP
        /// </summary>
        /// <param name="remoteEpAndLocalPortNumber"></param>
        public UDPListener(int remoteEpAndLocalPortNumber)
        {
            RemoteEPIpAddress = IPAddress.Any;
            RemoteEPPortNumber = remoteEpAndLocalPortNumber;
        }

        #endregion

        /// <summary>
        /// Starts listening on the IP and port selected in the constructor
        /// </summary>
        public void StartListening()
        {
            IsListening = true;
            IPEndPoint remoteIpEndPoint = new IPEndPoint(RemoteEPIpAddress, RemoteEPPortNumber);
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

        /// <summary>
        /// Stops the listening
        /// </summary>
        public void StopListening()
        {
            IsListening = false;
        }
    }
}
