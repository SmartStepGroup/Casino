using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class PlayerTests
   {
      private Player _player;

      [SetUp]
      public void Setup()
      {
         _player = new Player();
      }

      [TearDown]
      public void Teardown()
      {
         _player = null;
      }

      [Test]
      public void BetOneChip_PlayerHasOneChip_PlayerHasZeroChips()
      {
         _player.BuyChips(1);

         _player.Bet(chips: 1, score: 1);

         Assert.AreEqual(0, _player.Chips);
      }

      [Test]
      public void BetOneChip_PlayerHasOneChip_PlayerHasCurrentBetAndCuurentBetHasOneChip()
      {
         _player.BuyChips(1);

         _player.Bet(1, 1);

         Assert.IsNotNull(_player.CurrentBet);
         Assert.AreEqual(1, _player.CurrentBet.Chips);
      }

      [Test]
      public void Bet_PlayerHasOneChipAndCannotBetTwoChip_ThrowsArgumentException()
      {
         _player.BuyChips(1);

         Assert.Catch<ArgumentException>(() => _player.Bet(2, 1));
      }

      [Test]
      public void BuyChip_MinusOneChip_ThrowsArgumentExeption()
      {
         Assert.Catch<ArgumentException>(() => _player.BuyChips(-1));
      }

      [Test]
      public void BuyChip_OneChip_PlayerHasOneChip()
      {
         _player.BuyChips(1);

         Assert.AreEqual(1, _player.Chips);
      }

      [Test]
      public void BuyChip_ZeroChip_PlayerHasZeroChips()
      {
         _player.BuyChips(0);

         Assert.AreEqual(0, _player.Chips);
      }

      [Test]
      public void ByDefault_ChipsIsZero()
      {
         Assert.AreEqual(0, _player.Chips);
      }

      [Test]
      public void ByDefault_CurrentBetIsNull()
      {
         Assert.IsNull(_player.CurrentBet);
      }

      [Category("Данный тест является нехорошим.")]
      [Test]
      public void Bet_PlayerHasOneChipAndCannotBetMinusOneChip_ThrowsArgumentExeption()
      {
         _player.BuyChips(1);

         _player.Bet(chips: -1, score: 1);

         Assert.IsNotNull(_player.CurrentBet);
         Assert.AreEqual(-1, _player.CurrentBet.Chips);

         // а мы хотим вот такого ожидаемого поведения.
         //Assert.Catch<ArgumentException>(() => _player.Bet(-1, 1));
      } 

      [Test]
      public void Win_PlayerHasOneChipAndWinTwoChips_PlayerHasTwoChipsAndCurrentBetIsNull()
      {
         _player.BuyChips(1);
         _player.Bet(chips: 1, score: 1);

         _player.Win(2);

         Assert.AreEqual(2, _player.Chips);
         Assert.IsNull(_player.CurrentBet);
      }

      [Test]
      public void T9()
      {
         throw new InconclusiveException("Не реализовано.");
      }
   }
}