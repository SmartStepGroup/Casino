using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.PerformanceData;
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

            InGame = game.AddPlayer(this);
            return InGame;
        }

        public bool InGame { get; set; }
        public Chips Cash { get; private set; } = new Chips(0);
        public void GoOutFromGame()
        {
            if (!InGame)
            {
                throw new InvalidOperationException();
            }
            InGame = false;
        }

        public void BuyChips(Chips chips)
        {
            Cash.Add(chips);
        }

        public virtual void Win()
        {
            
        }
    }

  
}
