using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	class RollDiceGameTests
	{
		[Test]
		public void ByDefault_HasZeroPlayers()
		{
			var game = new RollDiceGame();

			Assert.AreEqual(0, game.PlayerCount);
		}

		[Test]
		public void AfterXPlayersJoined_PlayersCountIsX([Range(1, 6, 1)]int x)
		{
			var game = new RollDiceGame();

			joinNewPlayers(game, playerscount: x);

			Assert.AreEqual(x, game.PlayerCount);
		}

		[Test]
		public void After7PlayersTriedToJoin_PlayersCountIs6()
		{
			var game = new RollDiceGame();

			try
			{
				joinNewPlayers(game, playerscount: 7);
			}
			catch
			{
			}

			Assert.AreEqual(6, game.PlayerCount);
		}

		private void joinNewPlayers(RollDiceGame game, int playerscount)
		{
			for (int i = 0; i < playerscount; i++)
			{
				new Player().Joins(game);
			}
		}
	}
}
