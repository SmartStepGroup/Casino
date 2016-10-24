using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class PlayerWith1ChipTests
   {
      private Player _playerWith1Chip;

      [SetUp]
      public void SetUp()
      {
        var player = new Player();
         player.BuyChips(1);
         _playerWith1Chip = player;
      }

      [Test]
      public void ChipsIncreaseBy2_PlayerHas3Chip()
      {
         _playerWith1Chip.BuyChips(2);

         Assert.AreEqual(1 + 2, _playerWith1Chip.Chips);
      }

      [Test]
      public void Bet1Chip_PlayerHasBet()
      {
         _playerWith1Chip.Bet(1, 3);
         
         Assert.IsNotNull(_playerWith1Chip.CurrentBet);
         Assert.AreEqual(1, _playerWith1Chip.CurrentBet.Chips);
      }

      [Test]
      public void Bet1Chip_PlayerHasNoChips()
      {
         _playerWith1Chip.Bet(1, 3);
         
         Assert.AreEqual(0, _playerWith1Chip.Chips);
      }

      
      [Test]
      public void Bet1Chip_PlayerHasNoChipsButHasBet_PlayerKeepCurrentBet()
      {
         _playerWith1Chip.Bet(1, 1);
         var currentBet = _playerWith1Chip.CurrentBet;

         try
         {
            _playerWith1Chip.Bet(1, 3);
         }
         catch { }

         Assert.AreEqual(currentBet, _playerWith1Chip.CurrentBet);
      }


   }
}