using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class PlayerTests
	{
		[Test]
		public void Join_IsInGame()
		{
			var player = new Player();
			var game = new RollDiceGame();

			player.Joins(game);

			Assert.True(player.IsInGame);
		}

		[Test]
		public void ByDefault_NotInGame()
		{
			var player = new Player();

			Assert.False(player.IsInGame);
		}

		[Test]
		public void Leave_DefaultPlayer_ThrowsInvalidOperationException()
		{
			var player = new Player();

			Assert.Catch<InvalidOperationException>(() => player.LeaveGame());
		}

		[Test]
		public void Leave_AfterJoin_IsNotInGame()
		{
			var player = new Player();
			player.Joins(new RollDiceGame());

			player.LeaveGame();

			Assert.False(player.IsInGame);
		}

		[Test]
		public void Leave_TwoTimesAfterJoin_ThrowsInvalidOperationException()
		{
			var player = new Player();
			player.Joins(new RollDiceGame());
			player.LeaveGame();

			Assert.Catch<InvalidOperationException>(() => player.LeaveGame());
		}

		[Test]
		public void Joins_IsInGame_ThrowsInvalidOperationException()
		{
			var player = new Player();
			player.Joins(new RollDiceGame());

			Assert.Catch<InvalidOperationException>(() => player.Joins(new RollDiceGame()));
		}

		[Test]
		public void ByDefault_HasNoChips()
		{
			var player = new Player();

			Assert.AreEqual(0, player.Chips);
		}

		[Test]
		public void BuyXChips_SetChipsToX([Values(1, 10, 100)] int x)
		{
			var player = new Player();

			player.BuyChips(x);

			Assert.AreEqual(x, player.Chips);
		}

		[Test]
		public void ByDefault_HasNoBet()
		{
			var player = new Player();

			Assert.IsNull(player.CurrentBet);
		}

		[Test]
		public void BetXOnY_SetsTheCorrespondingBet([Range(1, 100, 3)]int x, [Range(1, 6, 1)]int y)
		{
			var player = new Player();
			player.BuyChips(x);

			player.Bet(new Bet(chips: x, score: y));

			Assert.AreEqual(new Bet(chips: x, score: y), player.CurrentBet);
		}

		[Test]
		public void BetX_BoughtY_ThrowsInvalidOperationException([Range(1, 49, 3)]int x, [Range(50, 100, 7)]int y)
		{
			var player = new Player();
			player.BuyChips(x);

			Assert.Catch<InvalidOperationException>(() => player.Bet(new Bet(chips: y, score: 1)));
		}
	}
}