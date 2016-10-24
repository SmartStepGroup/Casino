using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerTests
    {
      [Test]
      public void ByDefault_PlayerHasNoChips()
      {
         var player = new Player();

         Assert.AreEqual(0, player.Chips);
      }

      [Test]
      public void ByDefault_PlayerHasNoBet()
      {
         var player = new Player();

         Assert.AreEqual(null, player.CurrentBet);
      }

       [Test]
       public void Buy1Chip_NewPlayer_PlayerHas1Chip()
       {
         var player = new Player();

         player.BuyChips(1);

         Assert.AreEqual(1, player.Chips);
       }

       [Test]
       public void ChipsIncreaseByInputValue_PlayerHas1Chips_PlayerHas3Chip()
       {
         var player = new Player();
         player.BuyChips(1);

         player.BuyChips(2);

         Assert.AreEqual(3, player.Chips);
       }

       [Test]
       public void BuyNegativeChipsCount_NewPlayer_ArgumentException()
       {
         var player = new Player();
         
         Assert.Catch<ArgumentException>(() => player.BuyChips(-1));
       }
      
      [Test]
       public void Bet1Chip_PlayerHas1Chip_PlayerHasBet()
       {
         var player = new Player();
         player.BuyChips(1);

         player.Bet(1, 3);
         
         Assert.AreNotEqual(null, player.CurrentBet);
       }

       [Test]
       public void Bet1Chip_PlayerHas1Chips_PlayerHasNoChips()
       {
         var player = new Player();
         player.BuyChips(1);

         player.Bet(1, 3);
         
         Assert.AreEqual(0, player.Chips);
       }

       [Test]
       public void Bet1Chip_PlayerHasNoChips_ArgumentException()
       {
         var player = new Player();

         Assert.Catch<ArgumentException>(() => player.Bet(1, 3));
         Assert.AreEqual(null, player.CurrentBet);
       }

       [Test]
       public void Bet1Chip_PlayerHasNoChipsButHasBet_PlayerNotLostCurrentBet()
       {
         var player = new Player();
         player.BuyChips(1);
         player.Bet(1, 1);
         var currentBet = player.CurrentBet;

         Assert.Catch<ArgumentException>(() => player.Bet(1, 3));
         Assert.AreEqual(currentBet, player.CurrentBet);
       }
   }
}