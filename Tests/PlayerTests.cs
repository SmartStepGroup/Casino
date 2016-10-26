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
	}
}