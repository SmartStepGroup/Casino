using Domain;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void Player_ByDefault_HasNoChips()
        {
            var player = new Player();
            Assert.AreEqual(0, player.Chips);
        }
		[Test]
		public void Player_Buys1Chips_Sets1Chip()
		{
			var player = new Player();
			player.BuyChips(1);

			Assert.AreEqual(1, player.Chips);
		}
		[Test]
		public void Player_WhenHas1Chip_Buys1ChipsMore_Sets2Chip()
		{
			var player = new Player();
			player.BuyChips(1);

			player.BuyChips(1);
			Assert.AreEqual(2, player.Chips);
		}
		[Test]
		public void Player_BuysNegativeChips_ThrowsArgumentException()
		{
			var player = new Player();
			var exception = Assert.Throws<ArgumentException>(() => { player.BuyChips(-1); });
		}
		[Test]
		public void Player_BuysTooManyChips_IntegerOverflow()
		{
			var player = new Player();
			player.BuyChips(int.MaxValue);

			player.BuyChips(1);
			Assert.Greater(0, player.Chips);
		}
		[Test]
		public void Player_With1ChipBets2Chips_ThrowsArgumentException()
		{
			var player = new Player();
			player.BuyChips(1);

			var exception = Assert.Throws<ArgumentException>(() => { player.Bet(2, 4); });
		}
		[Test]
		public void Player_With1ChipBets1Chip_Sets0Chips()
		{
			var player = new Player();
			player.BuyChips(1);

			player.Bet(1, 4);
			Assert.AreEqual(0, player.Chips);
		}
		[Test]
		public void Player_With1ChipBets1ChipAndWins6Chips_Sets6Chips()
		{
			var player = new Player();
			player.BuyChips(1);
			player.Bet(1, 4);

			player.Win(6);
			Assert.AreEqual(6, player.Chips);
		}
		[Test]
		public void Player_Bets_BetIsNotNull()
		{
			var player = new Player();
			player.BuyChips(1);
			player.Bet(1, 4);

			Assert.IsNotNull(player.CurrentBet);
		}
	}
}