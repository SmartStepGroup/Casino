using System.Collections.Generic;

namespace Domain
{
    public class Game
    {
        private int PlayersCounter = 0;

        public bool AddPlayer()
        {
            if (PlayersCounter >= 6)
                return false;

            PlayersCounter++;
            return true;
        }
    }
}