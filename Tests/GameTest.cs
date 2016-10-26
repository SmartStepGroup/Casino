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
         Game game = new Game();
         for (int i = 0; i < 6; i++)
         {
            new Player().Join(game);
         }

         Player player = new Player();
         player.Join(game);

         Assert.IsFalse(player.IsInGame);
      }
   }
}
