using System;
using Domain;
using NUnit.Framework;
using System.Linq;

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

			Assert.AreEqual(0, player.CurrentBet.Bets.Count);
		}

		[Test]
		public void BetXOnY_SetsTheCorrespondingBet([Range(1, 100, 3)]int x, [Range(1, 6, 1)]int y)
		{
			var player = new Player();
			player.BuyChips(x);

			player.Bet(new Bet(chips: x, score: y));

			Assert.IsTrue(player.CurrentBet.Bets.Contains(new Bet(chips: x, score: y)));
		}

		[Test]
		public void BetX_BoughtY_ThrowsInvalidOperationException([Range(1, 49, 3)]int x, [Range(50, 100, 7)]int y)
		{
			var player = new Player();
			player.BuyChips(x);

			Assert.Catch<InvalidOperationException>(() => player.Bet(new Bet(chips: y, score: 1)));
		}

		[Test]
		public void CanBetOnSeveralScores()
		{
			var player = new Player();
			player.BuyChips(3);

			player.Bet(new Bet(chips: 1, score: 1));
			player.Bet(new Bet(chips: 1, score: 2));
			player.Bet(new Bet(chips: 1, score: 3));

			Assert.AreEqual(3, player.CurrentBet.Bets.Intersect(new[] { new Bet(chips: 1, score: 1),
																   new Bet(chips: 1, score: 2),
																   new Bet(chips: 1, score: 3) }).Count());
		}

		[Test, Ignore]
		public void Win_HasBetOneChipAndThreeChipsOnLuckyScoreAndTwoChipsOnUnluckyScore_IncreasesChipsBy24()
		{
			var player = new Player();
			player.BuyChips(10);
			player.Bet(new Bet(chips: 1, score: 1));
			player.Bet(new Bet(chips: 3, score: 1));
			player.Bet(new Bet(chips: 2, score: 3));

			var chipsBeforeWin = player.Chips;

			player.Win(score: 1);

			Assert.AreEqual((chipsBeforeWin + 24), player.Chips);
		}
	}
}