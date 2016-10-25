using System;
using System.Security.Cryptography.X509Certificates;

namespace Domain {
    public class RollDiceGame {
        
        public Player Player { get; set; }

        public void Play(IDice dice) {
            var winningScore = dice.Roll();
            if (Player.CurrentBet.Score == winningScore) {
                Player.Win(Player.CurrentBet.Chips * 6);
            }
            else {
                Player.Lose();
            }
        }
    }

    public interface IDice
    {
       int Roll();
    }
}