using Server.Game;
using Server.Models.Network;
using System.Collections.Generic;

namespace Server.Services
{
    /// <summary>
    /// Provides matching mechanics to pair two players to a game.
    /// </summary>
    public class MatchMaker
    {
        private List<Client> _matchQueue;
        private readonly SessionManager SessionManager;

        public MatchMaker()
        {
            _matchQueue = new List<Client>();
            SessionManager = SessionManager.GetSessionManager();
        }

        public void AddToQueue()
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
