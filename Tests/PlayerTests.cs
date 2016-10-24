using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class PlayerTests
   {
      private static Player CreatePlayerWithOneChip()
      {
         var player = new Player();

         player.BuyChips(1);

         return player;
      }

      [Test]
      public void Bet_PlayerHasOneChipAndCanBetOneChip_BetWithOneChipInCurrentBetPlayerHasZeroChips()
      {
         var player = CreatePlayerWithOneChip();

         player.Bet(1, 1);

         Assert.AreEqual(0, player.Chips);
         Assert.IsNotNull(player.CurrentBet);
         Assert.AreEqual(1, player.CurrentBet.Chips);
      }

      [Test]
      public void Bet_PlayerHasOneChipAndCannotBetTwoChip_ThrowsArgumentException()
      {
         var player = CreatePlayerWithOneChip();

         Assert.Catch<ArgumentException>(() => player.Bet(2, 1));
      }

      [Test]
      public void BuyChip_MinusOneChip_ThrowsArgumentExeption()
      {
         var player = new Player();

         Assert.Catch<ArgumentException>(() => player.BuyChips(-1));
      }

      [Test]
      public void BuyChip_OneChip_PlayerHasOneChip()
      {
         var player = CreatePlayerWithOneChip();

         Assert.AreEqual(1, player.Chips);
      }

      [Test]
      public void BuyChip_ZeroChip_PlayerHasZeroChips()
      {
         var player = new Player();

         player.BuyChips(0);

         Assert.AreEqual(0, player.Chips);
      }

      [Test]
      public void ByDefault_ChipsIsZero()
      {
         var player = new Player();

         Assert.AreEqual(0, player.Chips);
      }

      [Test]
      public void ByDefault_CurrentBetIsNull()
      {
         var player = new Player();

         Assert.IsNull(player.CurrentBet);
      }

      [Test]
      public void Bet_PlayerHasOneChipAndCannotBetMinusOneChip_ThrowsArgumentExeption()
      {
         var player = CreatePlayerWithOneChip();
         
         Assert.Catch<ArgumentException>(() => player.Bet(-1, 1));
      }

      [Test]
      public void Win_PlayerHasOneChipAndWinTwoChips_PlayerHasTwoChipsAndCurrentBetIsNull()
      {
         var player = CreatePlayerWithOneChip();
         player.Bet(chips: 1, score: 1);

         player.Win(2);

         Assert.AreEqual(2, player.Chips);
         Assert.IsNull(player.CurrentBet);
      }

      [Test]
      public void T9()
      {
         throw new InconclusiveException("Не реализовано.");
      }
   }
}