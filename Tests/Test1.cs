using Domain;
using NUnit.Framework;
using System;

namespace Tests
{
   [TestFixture]
   public class PlayerTest
   {
      private Player player;

      [SetUp]
      public void Initialize()
      {
         player = new Player();
      }

      [Test]
      public void Player_ByDefault_HasNoChips()
      {
         Assert.AreEqual(0, player.Chips);
      }

      [Test]
      public void Player_Buys1Chips_Sets1Chip()
      {
         player.BuyChips(1);
         Assert.AreEqual(1, player.Chips);
      }

      [Test]
      public void Player_WhenHas1Chip_Buys1ChipsMore_Sets2Chip()
      {
         player.BuyChips(1);

         player.BuyChips(1);
         Assert.AreEqual(2, player.Chips);
      }

      [Test]
      public void Player_BuysNegativeChips_ThrowsArgumentException()
      {
         var exception = Assert.Throws<ArgumentException>(() => { player.BuyChips(-1); });
      }

      [Test]
      public void Player_BuysTooManyChips_IntegerOverflow()
      {
         player.BuyChips(int.MaxValue);

         player.BuyChips(1);
         Assert.Greater(0, player.Chips);
      }

      [Test]
      public void Player_With1ChipBets2Chips_ThrowsArgumentException()
      {
         player.BuyChips(1);
         var exception = Assert.Throws<ArgumentException>(() => { player.Bet(2, 4); });
      }

      [Test]
      public void Player_With1ChipBets1Chip_Has0Chips()
      {
         player.BuyChips(1);

         player.Bet(1, 4);
         Assert.AreEqual(0, player.Chips);
      }

      [Test]
      public void Player_With1ChipBets1ChipAndWins6Chips_Has6Chips()
      {
         player.BuyChips(1);
         player.Bet(1, 4);

         player.Win(6);
         Assert.AreEqual(6, player.Chips);
      }

      [Test]
      public void Player_Bets_BetIsNotNull()
      {
         player.BuyChips(1);
         player.Bet(1, 4);

         Assert.IsNotNull(player.CurrentBet);
      }

      [Test]
      [TestCase(10, 12)]
      [TestCase(1, 18)]
      [TestCase(2, 6)]
      public void Player_BetsAllChips_LoseGame(int score, int gameScore)
      {
         player.BuyChips(1);

         player.Bet(chips: player.Chips, score: score);

         var diceMock = new DiceMock(gameScore);
         var game = new RollDiceGame(diceMock);

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
         const int initialChips = 9;
         player.BuyChips(initialChips);

         player.Bet(chips: player.Chips, score: score);

         var diceMock = new DiceMock(gameScore);
         var game = new RollDiceGame(diceMock);

         player.Join(game);

         game.Play();

         Assert.AreEqual(initialChips * 6, player.Chips);
      }

      private class DiceMock : IDice
      {
         private int _resultValue;

         public DiceMock(int resultValue)
         {
            _resultValue = resultValue;
         }

         public int Get()
         {
            return _resultValue;
         }
      }
   }
}