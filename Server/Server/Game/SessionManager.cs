using Server.Models.Messaging.Game;
using Server.Models.Network;
using Server.Models.Utility;
using System;
using System.Collections.Generic;
using System.Net;

namespace Server.Game
{
    /// <summary>
    /// Manages active game sessions by mapping connected clients to their active game sessions. 
    /// Only a single session manager per server.
    /// </summary>
    public class SessionManager
    {
        private Dictionary<IPAddress, GameState> _gameSessions;
        private readonly TimeSpan InactivityThreshold;
        private static SessionManager _sessionManager;

        private SessionManager()
        {
            _gameSessions = new Dictionary<IPAddress, GameState>();
            InactivityThreshold = new TimeSpan(hours: 0, minutes: 0, seconds: 10);
        }

        public static SessionManager GetSessionManager()
        {
            if(_sessionManager == null)
            {
                _sessionManager = new SessionManager();
            }

            return _sessionManager;
        }

        public void SetInactivityThreshold(TimeSpan timeSpan)
        {

        }

        public void CreateGameSession(Match match)
        {
            GameState newGame = new GameState();

            _gameSessions.Add(match.Client0.ServerEP.Address, newGame);
            _gameSessions.Add(match.Client1.ServerEP.Address, newGame);
        }

        public void EndGameSession()
        {

        }

        /// <summary>
        /// Checks for and removes games which are no longer active.
        /// </summary>
        public void RemoveInactiveGameSessions()
        {

        }
    }
}
