using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TDD
{
    public class Player
    {
        private Game _game;

        public void Join(Game game)
        {
            if (IsInGame)
            {
                throw new InvalidOperationException();
            }

            _game = game;
            _game.NotifyNewPLayer(this);
        }

        public bool IsInGame { get { return _game != null; } }

        public void Leave()
        {
            if (IsInGame)
            {
                _game = null;
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }
}
