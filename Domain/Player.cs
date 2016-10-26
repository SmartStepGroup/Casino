using System;

namespace Domain
{
   public class Player
   {
      public bool IsInGame { get; private set; }

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
   }
}


