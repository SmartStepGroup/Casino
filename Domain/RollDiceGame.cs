using System;

namespace Domain
{
   public class RollDiceGame
   {
      private readonly IDice _dice;

      public RollDiceGame(IDice dice)
      {
         if (dice == null)
         {
            throw new ArgumentNullException();
         }

         _dice = dice;
      }

      public IPlayer Player { get; set; }

      public void Play()
      {
         var winningScore = _dice.Roll();
         if (Player.CurrentBet.Score == winningScore)
         {
            Player.Win(Player.CurrentBet.Chips * 6);
         }
         else
         {
            Player.Lose();
         }
      }
   }
}