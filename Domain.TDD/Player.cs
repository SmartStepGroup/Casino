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
            IsInGame = true;
        }

        public bool IsInGame { get; private set; }
    }
}
