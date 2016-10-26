using System;

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
   }
}