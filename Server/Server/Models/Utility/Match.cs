using Server.Models.Network;

namespace Server.Models.Utility
{
    /// <summary>
    /// A Utility class that represents two clients that have been matched for a game.
    /// </summary>
    public class Match
    {
        public Match(Client client0, Client client1)
        {
            Client0 = client0;

            Client1 = client1;
        }

        public Client Client0 { get; set; }

        public Client Client1 { get; set; }
    }
}
