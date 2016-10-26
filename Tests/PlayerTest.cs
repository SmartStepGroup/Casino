using System;
using System.Threading;
using Domain;
using Moq;
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

      [Test]
      [TestCase(0)]
      [TestCase(1)]
      [TestCase(2)]
      [TestCase(3)]
      [TestCase(10)]
      [TestCase(100)]
      [TestCase(1000)]
      public void BuyChips_PlayerByDefault_HasBoughtNumberChips(int chipsNumber)
      {
         var player = new Player();

         player.BuyChips(chipsNumber);

         Assert.AreEqual(chipsNumber, player.CountChips);
      }

      [Test]
      public void MakeBet_PlayerInGameWithChips_CanMakeBet()
      {
         var player = new Player();
         player.Join(new Game());

         player.MakeBet(It.IsAny<uint>());

         Assert.AreEqual(It.IsAny<uint>(), player.Bet.Chips);
      }
   }

   
}
