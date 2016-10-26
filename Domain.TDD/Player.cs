using System;
using System.Collections.Generic;

namespace Domain.TDD
{
   public class Player
   {
      private Game _game;
      private readonly List<Bet> _currentBets;

      public Player()
      {
         _currentBets = new List<Bet>();
      }

      public bool IsInGame
      {
         get { return _game != null; }
      }

      public Chips Chips { get; private set; }

      public IReadOnlyList<Bet> CurrentBets
      {
         get { return _currentBets; }
      }

      public void Join(Game game)
      {
         if (IsInGame)
            throw new InvalidOperationException();

         _game = game;
         _game.NotifyNewPlayer(this);
      }

      public void Leave()
      {
         if (IsInGame)
            _game = null;
         else
            throw new InvalidOperationException();
      }

      public void BuyChips(Casino casino, Chips chips)
      {
         Chips += chips;
      }

      public void Bet(Chips chips, Score score)
      {
         if (chips > Chips)
            throw new InvalidOperationException();

         Bet bet = new Bet(chips, score);

         _currentBets.Add(bet);
      }
   }
}