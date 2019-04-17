using Newtonsoft.Json;

namespace Server.Models.Messaging
{
    /// <summary>
    /// The parent POCO model class that all forms of Udp messaging inherit from.
    /// </summary>
    public class Message
    {
        [JsonProperty("msg_type")]
        public MessageTypes MessageType { get; set; }

        public enum MessageTypes
        {
            Handshake,
            GameState,
            PlayerUpdate
        }
    }
}
