using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Server.Game;
using Server.Models.Messaging;
using Server.Models.Network;
using Server.Models.Validation;
using System;
using System.Text;

namespace Server.Services
{
    /// <summary>
    /// Handles messages sent to the server and the server's replies.
    /// </summary>
    public class Messenger
    {
        public Messenger() { }

        /// <summary>
        /// Parses a message to determine its type to pass it to the right handler.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="udpState">The client the message came from.</param>
        public async void ProcessMessage(dynamic messageString, UdpState udpState)
        {
            ValidationResult validationResult = await Validation.ValidateMessageAsync(inputJson: messageString, objectType: typeof(Message), allowAdditionalProperties: true);

            if(validationResult.IsValid)
            {
                Message message = JsonConvert.DeserializeObject(messageString);
                switch (message.MessageType)
                {
                    case (0):
                        Handshake(udpState);
                        break;
                    case (1):
                        ProcessGameState(messageString, udpState);
                        break;
                    case (2):
                        break;
                    case (3):
                        ProcessQueueMatchRequest(messageString, udpState);
                        break;
                }
            }
        }

        /// <summary>
        /// Receives and replies to a handshake request.
        /// </summary>
        /// <param name="udpState"></param>
        private void Handshake(UdpState udpState)
        {
            Console.WriteLine($"Handshaking with {udpState.ServerEP.Address}...");
            byte[] reply = Encoding.ASCII.GetBytes("Pong!");

            udpState.UdpClient.Send(reply, reply.Length, udpState.ServerEP);
        }

        /// <summary>
        /// Consumes the GameState message and sends the server response out to the clients in the same game.
        /// </summary>
        /// <param name="gameState"></param>
        /// <param name="udpState"></param>
        private void ProcessGameState(dynamic gameState, UdpState udpState)
        {
            SessionManager sessionManager = SessionManager.GetSessionManager();
        }

        /// <summary>
        /// Consumes the QueueMatchRequest and adds the client to the matchmaking queue.
        /// </summary>
        private async void ProcessQueueMatchRequest(dynamic queueMatchRequest, UdpState udpState)
        {
            ValidationResult validationResult = await Validation.ValidateMessageAsync(inputJson: queueMatchRequest, objectType: typeof(QueueMatchRequest), allowAdditionalProperties: true);

        }

        /// <summary>
        /// Sends a disconnection error message to the given <paramref name="client"/>
        /// stating that their game partner disconnected.
        /// </summary>
        /// <param name="client">The client to send error message to.</param>
        public void SendPartnerDisconnectMessage(UdpState udpState)
        {
            //The client that disconnected should message the user itself. i.e. the client should check for disconnection from the server.
            //The server should also know when a client has disconnected
        }
    }
}
