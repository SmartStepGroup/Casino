using System;

namespace Domain {
    public class RollDiceGame {
        private readonly IDice _dice;

       public RollDiceGame(IDice dice)
       {
          if (dice == null)
          {
             throw new ArgumentNullException("dice");
          }

          _dice = dice;
       }

        public Player Player { get; set; }

        public void Play() {
            var winningScore = _dice.Get();

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
      int Get();
   }

   public class Dice: IDice
   {
      private readonly Random _dice = new Random();

      public int Get()
      {
         return _dice.Next(1, 7);
      }
   }
}