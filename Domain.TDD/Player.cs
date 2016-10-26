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
            _game.NotifyNewPlayer(this);
        }

        public bool IsInGame { get { return _game != null; } }
        public Chips Chips { get; private set; }
        public Bet CurrentBet { get; set; }

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

        public void BuyChips(Casino casino, Chips chips)
        {
            Chips += chips;
        }

        public void Bet(Chips chips, Score score)
        {
            CurrentBet = new Bet(chips, score);
        }
    }
}
