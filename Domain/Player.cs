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
        public void Join(Game game)
        {
            InGame = true;

        }

        public bool InGame { get; set; }

        public void GoOutFromGame()
        {
            if (!InGame)
            {
                throw new InvalidOperationException();
            }
            InGame = false;
        }
    }
}
