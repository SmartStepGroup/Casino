using System;

namespace Domain
{
    public class Player
    {
        public bool IsInGame { get; set; }
        public int Chips { get; set; }
        public Bet CurrentBet { get; set; }

        public void Join(RollDiceGame game)
        {
            if (IsInGame)
            {
                throw new InvalidOperationException();
            }
            game.PlayerCount++;
            IsInGame = true;
        }

        public void LeaveGame()
        {
            if (!IsInGame)
            {
                throw new InvalidOperationException();
            }
            IsInGame = false;
        }

        public void BuyChips(int chips)
        {
            Chips += chips;
        }

        public void Bet(int chips, int score)
        {
            CurrentBet = new Bet();
        }
    }

    public class Bet
    {
        public int Chips => 1;
        public int Score => 1;
    }
}