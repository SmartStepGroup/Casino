using System;
using Domain.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests.TDD
{
   [TestFixture]
   [TestClass]
   public class PlayerTests
   {
      [Test]
      [TestMethod]
      public void Bet_PlayerWithoutBet_PlayerHasBetWithCorrectValues()
      {
         var player = new Player();
         var casino = new Casino();
         player.BuyChips(casino, (Chips) 1);

         player.Bet((Chips) 1, (Score) 2);

         Assert.IsNotNull(player.CurrentBet);
         Assert.AreEqual((Chips) 1, player.CurrentBet.Chips);
         Assert.AreEqual((Score) 2, player.CurrentBet.Score);
      }

      [Test]
      [TestMethod]
      public void Bet6Chips_PlayerHas5Chips_ThrowsInvalidOperationException()
      {
         var player = new Player();
         var casino = new Casino();
         player.BuyChips(casino, (Chips) 5);

         Assert.Catch<InvalidOperationException>(() => player.Bet((Chips) 6, (Score) 2));
      }

      [Test]
      [TestMethod]
      public void BuyChips_PlayerAndCasino_PlayerHasChips()
      {
         var player = new Player();
         var casino = new Casino();

         player.BuyChips(casino, (Chips) 6);

         Assert.AreEqual((Chips) 6, player.Chips);
      }

      [Test]
      [TestMethod]
      public void Join_NewPlayer_InGame()
      {
         var player = new Player();
         var game = new Game();

         player.Join(game);

         Assert.IsTrue(player.IsInGame);
      }

      [Test]
      [TestMethod]
      public void Join_PlayerIsInGame_ThrowsInvalidOperationException()
      {
         var player = new Player();
         var game = new Game();
         player.Join(game);

         Assert.Catch<InvalidOperationException>(() => player.Join(game));
      }

      [Test]
      [TestMethod]
      public void JoinAnother_6PlayersInGame_ThrowsInvaliOperationException()
      {
         var game = new Game();
         new Player().Join(game);
         new Player().Join(game);
         new Player().Join(game);
         new Player().Join(game);
         new Player().Join(game);
         new Player().Join(game);

         Assert.Catch<InvalidOperationException>(() => new Player().Join(game));
      }

      [Test]
      [TestMethod]
      public void Leave_NewPlayer_NotInGame()
      {
         var player = new Player();
         var game = new Game();
         player.Join(game);

         player.Leave();

         Assert.IsFalse(player.IsInGame);
      }

      [Test]
      [TestMethod]
      public void Leave_PlayerIsNotInGame_ThrowsInvalidOperationException()
      {
         var player = new Player();

         Assert.Catch<InvalidOperationException>(() => player.Leave());
      }
   }
}