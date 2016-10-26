using System;
using System.Collections.Generic;

namespace Domain
{
   public class Player
   {
      public bool IsInGame
      {
         get
         {
            return _game != null;
         }
      }

      public int Chips { get; private set; }

      public void Join(Game game)
      {
         if (game == null)
         {
            throw new ArgumentNullException("game");
         }

         if (_game != null) throw new InvalidOperationException();
         game.OnPlayerJoin(this);

         _game = game;
      }

      private Game _game;

      public void Leave()
      {
         if (_game == null) throw new InvalidOperationException();
         _game = null;
      }

      public void BuyChips(int chips)
      {
         if (chips <= 0)
         {
            throw new ArgumentException();
         }

         Chips += chips;
      }

      public void Bet(int playerChips, int score)
      {
         if (playerChips > Chips)
         {
            throw new InvalidOperationException();
         }

         Chips -= playerChips;
         _availableBets.Add(new BetsWithChips()
         {
            Chips = playerChips,
            Score = score
         });
      }

      public int GetBetAmountOnScore(int i)
      {
         throw new NotImplementedException();
      }

      public bool HasAnyBet()
      {
         return _availableBets.Count > 0;
      }

      private readonly List<BetsWithChips> _availableBets = new List<BetsWithChips>();

      private struct BetsWithChips
      {
         public int Chips;

         public int Score;
      }
   }
}