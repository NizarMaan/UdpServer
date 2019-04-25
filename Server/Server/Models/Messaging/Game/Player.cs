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
            MessageType = (int) MessageTypes.PlayerUpdate;
            Health = 100;
        }

        [JsonProperty("position", Required = Required.Always)]
        public Position Position { get; set; }

        [JsonProperty("health", Required = Required.Always)]
        public int Health { get; set; }
    }
}
