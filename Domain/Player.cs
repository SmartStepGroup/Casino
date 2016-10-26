using System;

namespace Domain
{
    public class Player
    {
        public bool IsInGame { get; set; }

        public void Join(RollDiceGame game)
        {
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
    }
}