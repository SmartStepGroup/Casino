﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class GameTests
   {
      [Test]
      public void Game_Allows6PlayersToJoin()
      {
         var game = new Game();

         for (int i = 0; i < 6; ++i)
         {
            var player = new Player();
            player.Join(game);
         }

         Assert.AreEqual(6, game.Players);
      }
      [Test]
      public void Game_Disallows7PlayersToJoin()
      {
         var game = new Game();

         for (int i = 0; i < 6; ++i)
         {
            var player = new Player();
            player.Join(game);
         }

         var playerWhichDoesntFit = new Player();
         Assert.Catch<InvalidOperationException>(() => playerWhichDoesntFit.Join(game));
      }
   }
}
