using System;

namespace Server.Models.Network
{
    /// <summary>
    /// Defines a Udp/game client that would connect to the server.
    /// </summary>
    public class Client
    {
        public enum Status
        {
            InGame,
            InQueue
        }

        public string ClientId { get; set; }

        public Status GameStatus { get; set; }

        public UdpState UdpState { get; set; }

        public DateTime LastMessageReceivedAt { get; set; }
    }
}
