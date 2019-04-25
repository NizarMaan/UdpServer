namespace Server.Models.Messaging
{
    /// <summary>
    /// Defines the required parameters for an authentication handshake from a <see cref="Network.Client"/>.
    /// </summary>
    public class Handshake : Message
    {
        public Handshake() : base()
        {
            MessageType = (int) MessageTypes.Handshake;
        }
    }
}
