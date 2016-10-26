using System;
using System.Collections.Generic;

namespace Domain
{
   public class Player
   {
      private Bet[] _bets = new[]
      {
         new Bet(new Chip(0), new Score(1)),
         new Bet(new Chip(0), new Score(2)),
         new Bet(new Chip(0), new Score(3)),
         new Bet(new Chip(0), new Score(4)),
         new Bet(new Chip(0), new Score(5)),
         new Bet(new Chip(0), new Score(6)),
      }; 

      public bool IsInGame { get; private set; }

      public Chip Chips { get; private set; }

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
         var bet = GetBet(score);

         _bets[score.Number - 1] = new Bet(new Chip(bet.Chips.Count + chips.Count), score);
      }

      public Bet GetBet(Score score)
      {
         return _bets[score.Number-1];
      }
   }
}


