using Server.Models.Network;

namespace Server.Services
{
    /// <summary>
    /// Handles sending messages to <see cref="Client"/>s.
    /// </summary>
    public class MessageSender
    {
        /// <summary>
        /// Sends a disconnection error message to the given <paramref name="client"/>
        /// stating that their game partner disconnected.
        /// </summary>
        /// <param name="client">The client to send error message to.</param>
        public void SendPartnerDisconnectMessage(Client client)
        {
            //The client that disconnected should message the user itself. i.e. the client should check for disconnection from the server.
            /*
            foreach(GameState gameState in _gameSessions.Values)
            {
                if(DateTime.Now - gameState.client.LastMessageReceivedAt >= InactivityThreshold)
                {
                    _gameSessions.Remove(client.UdpState.ServerEP.Address);
                }
            }
             */
        }
    }
}
