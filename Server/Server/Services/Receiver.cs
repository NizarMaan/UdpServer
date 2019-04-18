using Server.Models.Network;

namespace Server.Services
{
    /// <summary>
    /// Handles messages sent to the server.
    /// </summary>
    public class Receiver
    {
        public Receiver() { }

        public void ParseMessage(string message, UdpState udpState)
        {
            Validation.ValidateJsonAsync()
        }
    }
}
