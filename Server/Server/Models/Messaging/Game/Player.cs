using Newtonsoft.Json;

namespace Server.Models.Messaging.Game
{
    /// <summary>
    /// Defines a player's state in a <see cref="Game.GameState"/>.
    /// </summary>
    public class Player : Message
    {
        public Player() : base()
        {
            MessageType = MessageTypes.PlayerUpdate;
        }

        [JsonProperty("position", Required = Required.Always)]
        public Position Position { get; set; }
    }
}
