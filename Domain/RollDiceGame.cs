using System;

namespace Domain {
    public class RollDiceGame {

        private readonly IDice _dice;
        public Player Player { get; set; }

       public RollDiceGame(IDice dice)
       {
          _dice = dice;
       }

        public void Play() {
            var winningScore = _dice.Roll();
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

   public class Dice : IDice
   {
      private readonly Random _dice = new Random();

      public int Roll()
      {
         return _dice.Next(1, 7);
      }
   }
}