using Newtonsoft.Json;
using System;
using System.Net;

namespace Server.Models.Messaging.Game
{
    /// <summary>
    /// Defines a player's state in a <see cref="Game.GameState"/>.
    /// </summary>
    public class Player : Message
    {
        public Player() : base()
        {
            MessageType = (int) MessageTypes.PlayerUpdate;
            Health = 100;
        }

        [JsonProperty("ip_address", Required = Required.Always)]
        public IPAddress ip_address { get; set; }

        [JsonProperty("position", Required = Required.Always)]
        public Position Position { get; set; }

        [JsonProperty("health", Required = Required.Always)]
        public int Health { get; set; }

        [JsonProperty("last_message_sent_at", Required = Required.Always)]
        public DateTime LastMessageSentAt { get; set; }
    }
}
