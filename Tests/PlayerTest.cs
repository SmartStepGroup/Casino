using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class PlayerTest
   {
      [Test]
      public void Join_Player_PlayerInGame()
      {
         var player = new Player();

         player.Join(new Game());

         Assert.IsTrue(player.IsInGame);
      }

      [Test]
      public void Leave_PlayerInGame_PlayerNotInGame()
      {
         var player = new Player();
         player.Join(new Game());

         player.Leave();

         Assert.IsFalse(player.IsInGame);
      }

      [Test]
      public void Leave_PlayerNotInGame_ThrowInvalidOperationException()
      {
         var player = new Player();

         Assert.Catch<InvalidOperationException>(player.Leave);
      }

      [Test]
      public void Join_IsInGame_InvalidOperationException()
      {
         var player = new Player();
         player.Join(new Game());

         Assert.Catch<InvalidOperationException>(() => player.Join(new Game()));
      }
   }
}
