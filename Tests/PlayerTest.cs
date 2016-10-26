using System;
using System.Configuration;
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

         player.MakeBet(It.IsAny<int>());

         Assert.AreEqual(It.IsAny<int>(), player.Bet.Chips);
      }

      [Test]
      [TestCase(10, 11)]
      [TestCase(5, 8)]
      [TestCase(100, 120)]
      [TestCase(1, 13)]
      [TestCase(9, 110)]
      public void MakeBetChipsMoreThenPlayerHas_PlayerInGameWithChips_ThrowInvalidOperationException(int chipsNumberPlayerHas, int chipsNumberPlayerBets)
      {
         var player = new Player();
         player.Join(new Game());
         player.BuyChips(chipsNumberPlayerHas);

         Assert.Catch<InvalidOperationException>(() => player.MakeBet(chipsNumberPlayerBets));
      }

      [Test]
      [TestCase(11,10)]
      [TestCase(100, 15)]
      [TestCase(1, 1)]
      public void PlayerCanBetIfHasSufficientChips(int chipsNumberPlayerHas, int chipsNumberPlayerBets)
      {
         var player = new Player();
         player.Join(new Game());
         player.BuyChips(chipsNumberPlayerHas);

         player.MakeBet(chipsNumberPlayerBets);

         Assert.AreEqual(chipsNumberPlayerBets, player.Bet.Chips);
      }
   }

   
}
