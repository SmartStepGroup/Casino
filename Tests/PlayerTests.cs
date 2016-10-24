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
      public void SetUp()
      {
         _player = new Player();
      }

      [Test]
      public void ByDefault_PlayerHasNoChips()
      {
         Assert.AreEqual(0, _player.Chips);
      }

      [Test]
      public void ByDefault_PlayerHasNoBet()
      {
         Assert.IsNull(_player.CurrentBet);
      }

       [Test]
       public void Buy1Chip_NewPlayer_PlayerHas1Chip()
       {
         _player.BuyChips(1);

         Assert.AreEqual(1, _player.Chips);
       }
     
       [Test]
       public void BuyNegativeChipsCount_NewPlayer_ArgumentException()
       {
         Assert.Catch<ArgumentException>(() => _player.BuyChips(-1));
       }

       [Test]
       public void Bet1Chip_PlayerHasNoChips_ArgumentException()
       {
         Assert.Catch<ArgumentException>(() => _player.Bet(1, 3));
         Assert.AreEqual(null, _player.CurrentBet);
       }
   }
}