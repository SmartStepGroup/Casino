using System;

namespace Domain
{
   public class Game
   {
      public int Players { get; private set; }

      public void OnPlayerJoin(Player player)
      {
         if (Players >= 6)
         {
            throw new InvalidOperationException();
         }
         ++Players;
      }
   }
}