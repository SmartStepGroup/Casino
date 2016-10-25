using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class GameTest
   {
      private Player player;
      const int initialChips = 9;

      [SetUp]
      public void Initialize()
      {
         player = new Player();
         player.BuyChips(initialChips);
      }

      [Test]
      [TestCase(10, 12)]
      [TestCase(1, 18)]
      [TestCase(2, 6)]
      public void Player_BetsAllChips_LoseGame(int score, int gameScore)
      {
         player.Bet(chips: player.Chips, score: score);

         var game = CreateGame(gameScore);

         player.Join(game);

         game.Play();

         Assert.AreEqual(0, player.Chips);
      }

      [Test]
      [TestCase(10, 10)]
      [TestCase(18, 18)]
      [TestCase(6, 6)]
      public void Player_BetsAllChips_WinGame(int score, int gameScore)
      {
         player.Bet(chips: player.Chips, score: score);
         
         var game = CreateGame(gameScore);

         player.Join(game);

         game.Play();

         Assert.AreEqual(initialChips * 6, player.Chips);
      }

      private static RollDiceGame CreateGame(int gameScore)
      {
         var diceMock = new Mock<IDice>();
         diceMock.Setup((m) => m.Get()).Returns(gameScore);

         var game = new RollDiceGame(diceMock.Object);

         return game;
      }
   }
}
