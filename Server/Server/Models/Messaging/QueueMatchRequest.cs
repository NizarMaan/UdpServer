namespace Server.Models.Messaging
{
    /// <summary>
    /// Defines the structure of a udp message requesting a match/game.
    /// </summary>
    public class QueueMatchRequest : Message
    {
        public QueueMatchRequest() : base()
        {
            MessageType = MessageTypes.QueueMatchRequest;
        }
    }
}
