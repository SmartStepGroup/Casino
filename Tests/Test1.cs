using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class PlayerTest
   {
      private const int DEFAULT_SCORE_VALUE = 1;

      private const int DEFAULT_BUY_CHIPS_VALUE = 1;

      private const int DEFAULT_BET_CHIPS_VALUE = 1;

      private Player _player;

      [SetUp]
      public void Setup()
      {
         _player = new Player();
      }

      [Test]
      public void ByDefault_ChipsIs0()
      {
         Assert.AreEqual(0, _player.Chips);
      }

      [Test]
      public void BuyDefaultValueChip_ChipsIsDefaultValue()
      {
         _player.BuyChips(DEFAULT_BUY_CHIPS_VALUE);

         Assert.AreEqual(DEFAULT_BUY_CHIPS_VALUE, _player.Chips);
      }

      [Test]
      public void BuyNegativeChip1_ThrowArgumentException()
      {
         var exception = Assert.Catch<ArgumentException>(() => _player.BuyChips(-1));

         Assert.AreEqual("Are you cheating?", exception.Message);
      }

      [Test]
      public void BuyChip0_ChipsIs0()
      {
         _player.BuyChips(0);

         Assert.AreEqual(0, _player.Chips);
      }

      [Test]
      public void BuyMaxIntChips_ChipsIsIntMax()
      {
         _player.BuyChips(int.MaxValue);

         Assert.AreEqual(int.MaxValue, _player.Chips);
      }

      [Test]
      public void BuyMaxIntChips_HaveDefaultValueChips_ThrowOverflowException()
      {
         _player.BuyChips(DEFAULT_BUY_CHIPS_VALUE);

         var exception = Assert.Catch<OverflowException>(() => _player.BuyChips(int.MaxValue));
      }

      [Test]
      public void BetDefaultValueChip_PlayerHasNoChips_ThrowArgumentException()
      {
         var ex = Assert.Catch<ArgumentException>(() => _player.Bet(DEFAULT_BET_CHIPS_VALUE, DEFAULT_SCORE_VALUE));

         Assert.AreEqual("Have you spend all your money already?", ex.Message);
      }

      [Test]
      public void BetNegativeChips_PlayerHasNoChip_ThrowArgumentException()
      {
         var ex = Assert.Catch<ArgumentException>(() => _player.Bet(chips: -1, score: DEFAULT_SCORE_VALUE));

         Assert.AreEqual("We know.", ex.Message);
      }

      [Test]
      public void BetDefaultValueChip_PlayerHasDefaultValueChip_PlayerHasNoChip()
      {
         _player.BuyChips(DEFAULT_BUY_CHIPS_VALUE);

         _player.Bet(chips: DEFAULT_BET_CHIPS_VALUE, score:DEFAULT_SCORE_VALUE);

         Assert.AreEqual(DEFAULT_BUY_CHIPS_VALUE - DEFAULT_BET_CHIPS_VALUE, _player.Chips);
      }


      [Test]
      public void BetDefaultValueChip_PlayerHasDefaultValueChip_CurrentBetChipsDefaultValue()
      {
         _player.BuyChips(DEFAULT_BUY_CHIPS_VALUE);

         _player.Bet(DEFAULT_BET_CHIPS_VALUE, DEFAULT_SCORE_VALUE);

         Assert.AreEqual(DEFAULT_BET_CHIPS_VALUE, _player.CurrentBet.Chips);
      }

      [Test]
      public void BetScoreDefaultValue_PlayerHasChipsToScore_CurrentBetScoreDefaultValue()
      {
         _player.BuyChips(DEFAULT_BUY_CHIPS_VALUE);

         _player.Bet(DEFAULT_BET_CHIPS_VALUE, DEFAULT_SCORE_VALUE);

         Assert.AreEqual(DEFAULT_SCORE_VALUE, _player.CurrentBet.Score);
      }
   }
}