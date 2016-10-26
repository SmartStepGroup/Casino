using System.Collections.Generic;

namespace Domain
{
    public class Game
    {
        private readonly List<Player> _scopePlayers = new List<Player>();


        public bool AddPlayer(Player player)
        {
            
            if (_scopePlayers.Count >= 6)
                return false;

            _scopePlayers.Add(player);
            return true;
        }

        public void Play()
        {
            foreach (var player in _scopePlayers)
            {
                player.Win();
            }
        }
    }
}