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
      public void Join_IsInGame_InvalidOperationException()
      {
         var player = new Player();
         player.Join(new Game());

         Assert.Catch<InvalidOperationException>(() => player.Join(new Game()));
      }
   }
}

/*
 + Я, как игрок, могу войти в игру
+ Я, как игрок, могу выйти из игры
Я, как игрок, не могу выйти из игры, если я в нее не входил
Я, как игрок, могу играть только в одну игру одновременно
Я, как игра, не позволяю войти более чем 6 игрокам
    */
