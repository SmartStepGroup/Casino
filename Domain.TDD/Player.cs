using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TDD
{
    public class Player
    {
        public void Join(Game game)
        {
            if (IsInGame)
            {
                throw new InvalidOperationException();
            }

            IsInGame = true;
        }

        public bool IsInGame { get; private set; }

        public void Leave()
        {
            if (IsInGame)
            {
                IsInGame = false;
            }
            else
            {
                throw new InvalidOperationException();
            }

        }
    }
}
