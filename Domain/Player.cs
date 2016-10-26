using System;

namespace Domain
{
   public class Player
   {
      public bool IsInGame { get; private set; }

      public Chip Chips { get; private set; }

      public Bet Bet { get; set; }

      public void BuyChips(Chip chipsNumber)
      {
         Chips = chipsNumber;
      }

      public void Join(Game game)
      {
         if (IsInGame)
         {
            throw new InvalidOperationException();
         }

         if (game.CountPlayers >= 6)
         {
            return;
         }

         game.JoinPlayer(this);
         IsInGame = true;
      }

      public void Leave()
      {
         if (!IsInGame)
         {
            throw new InvalidOperationException();
         }

         IsInGame = false;
      }

      public void MakeBet(Chip chips, Score score)
      {
         if (this.Chips.Count < chips.Count)
         {
            throw new InvalidOperationException();
         }

         Bet = new Bet(chips, score);
      }
   }
}


