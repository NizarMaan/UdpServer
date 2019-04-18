using Newtonsoft.Json;

namespace Server.Models.Messaging.Game
{
    /// <summary>
    /// Defines a game object's coordinate position in the game world.
    /// </summary>
    public class Position : Message
    {
        [JsonProperty("x_coordinate", Required = Required.Always)]
        public double XCoordinate { get; set; }

        [JsonProperty("y_coordinate", Required = Required.Always)]
        public double YCoordinate { get; set; }

        [JsonProperty("z_coordinate", Required = Required.Always)]
        public double ZCoordinate { get; set; }
    }
}
