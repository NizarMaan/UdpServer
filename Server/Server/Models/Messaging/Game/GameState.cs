using Newtonsoft.Json;
using System.Collections.Generic;

namespace Server.Models.Messaging.Game
{
    /// <summary>
    /// Defines a the state of a game session.
    /// </summary>
    public class GameState : Message
    {
        public GameState() : base()
        {
            MessageType = MessageTypes.GameState;
        }

        [JsonProperty("players", Required = Required.Always)]
        public List<Player> Players { get; set; }
    }
}
