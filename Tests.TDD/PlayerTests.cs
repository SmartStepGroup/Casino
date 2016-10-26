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
         var casino = new Casino();
         var player = new Player(casino);
         player.BuyChips(casino, (Chips) 10);

         player.Bet((Chips) 10, (Score) 2);

         Assert.AreEqual(1, player.CurrentBets.Count);
         Assert.AreEqual((Chips) 10, player.CurrentBets[0].Chips);
         Assert.AreEqual((Score) 2, player.CurrentBets[0].Score);
      }

      [Test]
      [TestMethod]
      public void Bet6Chips_PlayerHas5Chips_ThrowsInvalidOperationException()
      {
         var casino = new Casino();
         var player = new Player(casino);
         player.BuyChips(casino, (Chips) 5);

         Assert.Catch<InvalidOperationException>(() => player.Bet((Chips) 6, (Score) 2));
      }

      [Test]
      [TestMethod]
      public void BetTwoBet_PlayerWithChips_PLayerHasTwoBets()
      {
         var casino = new Casino();
         var player = new Player(casino);
         player.BuyChips(casino, (Chips) 30);

         player.Bet((Chips) 10, (Score) 1);
         player.Bet((Chips) 20, (Score) 2);

         Assert.AreEqual(2, player.CurrentBets.Count);
         Assert.AreEqual((Chips) 10, player.CurrentBets[0].Chips);
         Assert.AreEqual((Score) 1, player.CurrentBets[0].Score);
         Assert.AreEqual((Chips) 20, player.CurrentBets[1].Chips);
         Assert.AreEqual((Score) 2, player.CurrentBets[1].Score);
      }

      [Test]
      [TestMethod]
      public void BuyChips_PlayerAndCasino_PlayerHasChips()
      {
         var casino = new Casino();
         var player = new Player(casino);

         player.BuyChips(casino, (Chips) 6);

         Assert.AreEqual((Chips) 6, player.Chips);
      }

      [Test]
      [TestMethod]
      public void Join_NewPlayer_InGame()
      {
         var casino = new Casino();
         var player = new Player(casino);
         var game = new Game();

         player.Join(game);

         Assert.IsTrue(player.IsInGame);
      }

      [Test]
      [TestMethod]
      public void Join_PlayerIsInGame_ThrowsInvalidOperationException()
      {
         var casino = new Casino();
         var player = new Player(casino);
         var game = new Game();
         player.Join(game);

         Assert.Catch<InvalidOperationException>(() => player.Join(game));
      }

      [Test]
      [TestMethod]
      public void JoinAnother_6PlayersInGame_ThrowsInvalidOperationException()
      {
         var game = new Game();
         var casino = new Casino();
         new Player(casino).Join(game);
         new Player(casino).Join(game);
         new Player(casino).Join(game);
         new Player(casino).Join(game);
         new Player(casino).Join(game);
         new Player(casino).Join(game);

         Assert.Catch<InvalidOperationException>(() => new Player(casino).Join(game));
      }

      [Test]
      [TestMethod]
      public void Leave_NewPlayer_NotInGame()
      {
         var casino = new Casino();
         var player = new Player(casino);
         var game = new Game();
         player.Join(game);

         player.Leave();

         Assert.IsFalse(player.IsInGame);
      }

      [Test]
      [TestMethod]
      public void Leave_PlayerIsNotInGame_ThrowsInvalidOperationException()
      {
         var casino = new Casino();
         var player = new Player(casino);

         Assert.Catch<InvalidOperationException>(() => player.Leave());
      }
   }
}