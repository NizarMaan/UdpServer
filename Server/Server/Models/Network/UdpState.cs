using System.Net;
using System.Net.Sockets;

namespace Server.Models.Network
{
    /// <summary>
    /// Defines the state of a client.
    /// </summary>
    public class UdpState
    {
        public UdpClient UdpClient;
        public IPEndPoint ServerEP;
    }
}
