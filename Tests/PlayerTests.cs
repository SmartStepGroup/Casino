using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class PlayerTests
   {
      [Test]
      public void Player_CanEnterGame()
      {
         var player = new Player();
         var game = new Game();

         player.Join(game);

         Assert.True(player.IsInGame);
      }

      [Test]
      public void Player_CanLeaveGame()
      {
         var player = new Player();
         var game = new Game();

         player.Join(game);
         player.Leave();

         Assert.False(player.IsInGame);
      }

      [Test]
      public void Player_CantLeaveGame_IfNotInGame()
      {
         var player = new Player();
         Assert.Catch<InvalidOperationException>(() => player.Leave());
      }

      [Test]
      public void Player_CantLeaveGameTwice()
      {
         var player = new Player();
         var game = new Game();

         player.Join(game);
         player.Leave();

         Assert.Catch<InvalidOperationException>(() => player.Leave());
      }

      [Test]
      public void Player_CantJoinGameTwice()
      {
         var player = new Player();
         var game = new Game();

         player.Join(game);

         Assert.Catch<InvalidOperationException>(() => player.Join(game));
      }

      [Test]
      public void Player_CantJoinNullGame()
      {
         var player = new Player();

         Assert.Catch<ArgumentNullException>(() => player.Join(null));
      }
   }
}