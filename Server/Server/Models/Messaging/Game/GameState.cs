using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Server.Models.Messaging.Game
{
    /// <summary>
    /// Defines a the state of a game session.
    /// </summary>
    [Guid("936DA01F-9ABD-4d9d-80C7-02AF85C822A8")]

    public class GameState : Message
    {
        public GameState() : base()
        {
            MessageType = (int) MessageTypes.GameState;

            string MyAttribute = ((GuidAttribute)Attribute.GetCustomAttribute(typeof(GameState), typeof(GuidAttribute))).Value;

            Id = new Guid(MyAttribute).ToString();

        }

        [JsonProperty("id", Required = Required.Always)]
        public string Id { get; set; }

        [JsonProperty("players", Required = Required.Always)]
        public List<Player> Players { get; set; }
    }
}
