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
    }
}