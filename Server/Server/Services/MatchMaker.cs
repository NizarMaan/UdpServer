using Server.Game;
using Server.Models.Network;
using Server.Models.Utility;
using System.Collections.Generic;
using System.Net;

namespace Server.Services
{
    /// <summary>
    /// Provides matching mechanics to pair two players to a game. Singleton class, server should only have one matchmaker.
    /// Works as a first-in first-out queue. Matches adjacent clients together.
    /// </summary>
    public class MatchMaker
    {
        private Dictionary<IPAddress, UdpState> _matchQueue;
        private static MatchMaker _matchMaker;

        private MatchMaker()
        {
            _matchQueue = new Dictionary<IPAddress, UdpState>();
        }

        public static MatchMaker GetMatchMaker()
        {
            if(_matchMaker == null)
            {
                _matchMaker = new MatchMaker();
            }

            return _matchMaker;
        }

        public void AddToQueue(UdpState client)
        {
            _matchQueue.Add(client.ServerEP.Address, client);
        }

        public void RemoveFromQueue(UdpState client)
        {
            _matchQueue.Remove(client.ServerEP.Address);
        }

        /// <summary>
        /// Finds and creates a match between two clients in the <see cref="SessionManager"/>,
        /// and then notifies them of their match-up.
        /// </summary>
        public List<Match> FindAndCreateMatches()
        {
            List<Match> matches = new List<Match>();

            return matches;
        }
    }
}
