using System;

namespace Domain
{
    public class Player
    {
        public bool IsInGame { get; set; }
        public int Chips => 1;

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

        public void BuyChips(int i)
        {
        }
    }
}