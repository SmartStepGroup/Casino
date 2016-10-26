using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Player
    {
        public bool Join(Game game)
        {
            if (InGame)
            {
                throw new InvalidOperationException();
            }

            InGame = game.AddPlayer();
            return InGame;
        }

        public bool InGame { get; set; }
        public uint Chips { get; private set; }
        public void GoOutFromGame()
        {
            if (!InGame)
            {
                throw new InvalidOperationException();
            }
            InGame = false;
        }

        public void BuyChips(uint chips)
        {
            Chips += chips;
        }
    }
}
