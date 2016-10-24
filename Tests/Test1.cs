using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class PlayerTest
   {
      [Test]
      public void ByDefault_ChipsIs0()
      {
         var player = new Player();

         Assert.AreEqual(0, player.Chips);
      }

      [Test]
      public void Buy1Chip_ChipsIs1()
      {
         var player = new Player();

         player.BuyChips(1);

         Assert.AreEqual(1, player.Chips);
      }

      [Test]
      public void BuyNegativeChip1_ThrowArgumentException()
      {
         var player = new Player();

         var exception = Assert.Catch<ArgumentException>(() => player.BuyChips(-1));

         Assert.AreEqual("Are you cheating?", exception.Message);
      }

      [Test]
      public void BuyChip0_ChipsIs0()
      {
         var player = new Player();

         player.BuyChips(0);

         Assert.AreEqual(0, player.Chips);
      }

      [Test]
      public void BuyMaxIntChips_ChipsIsIntMax()
      {
         var player = new Player();

         player.BuyChips(int.MaxValue);

         Assert.AreEqual(int.MaxValue, player.Chips);
      }

      [Test]
      public void BuyMaxIntChips_HaveChips1_ThrowOverflowException()
      {
         var player = new Player();
         player.BuyChips(1);

         var exception = Assert.Catch<OverflowException>(() => player.BuyChips(int.MaxValue));
      }
   }
}