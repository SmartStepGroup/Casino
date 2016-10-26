using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class GameTest
   {
      [Test]
      public void Join7thPlayer_6PlayersInGame_7thPlayerNotInGame()
      {
         Game game = createGameWithPlayers(6);

         Player player = new Player();
         player.Join(game);

         Assert.IsFalse(player.IsInGame);
      }

      private Game createGameWithPlayers(int playerCount)
      {
         Game game = new Game();

         for (int i = 0; i < playerCount; i++)
         {
            new Player().Join(game);
         }

         return game;
      }
   }
}
