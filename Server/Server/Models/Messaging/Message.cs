using Newtonsoft.Json;

namespace Server.Models.Messaging
{
    /// <summary>
    /// The parent POCO model class that all forms of Udp messaging inherit from.
    /// </summary>
    public class Message
    {
        [JsonProperty("msg_type", Required = Required.Always)]
        public int MessageType { get; set; }

        public enum MessageTypes
        {
            Handshake,
            GameState,
            PlayerUpdate,
            QueueMatchRequest
        }
    }
}
