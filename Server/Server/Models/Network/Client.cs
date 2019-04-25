using System;

namespace Server.Models.Network
{
    /// <summary>
    /// Defines a Udp/game client that would connect to the server.
    /// </summary>
    public class Client
    {
        public enum StatusType
        {
            InGame,
            InQueue
        }

        public string ClientId { get; set; }

        public StatusType Status { get; set; }

        public UdpState UdpState { get; set; }

        public DateTime LastMessageReceivedAt { get; set; }
    }
}
