using Server.Game;
using Server.Models.Network;
using System.Collections.Generic;
using System.Net;

namespace Server.Services
{
    /// <summary>
    /// Provides matching mechanics to pair two players to a game.
    /// </summary>
    public class MatchMaker
    {
        private Dictionary<IPAddress, UdpState> _matchQueue;
        private readonly SessionManager SessionManager;

        public MatchMaker()
        {
            _matchQueue = new Dictionary<IPAddress, UdpState>();
            SessionManager = SessionManager.GetSessionManager();
        }

        public void AddToQueue(UdpState client)
        {

        }

        public void RemoveFromQueue()
        {

        }

        public void FindMatches()
        {

        }

        public void CreateMatch()
        {

        }
    }
}
