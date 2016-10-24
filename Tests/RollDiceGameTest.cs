// (c) Vladimir Krivopalov & Alexander Ivanov

using Domain;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class RollDiceGameTest
	{
		private Player _player;
		private RollDiceGame _game;

		[SetUp]
		public void SetUp()
		{
			_player = new Player();
			_game = new RollDiceGame()
			{
				Player = _player,
			};
			_player.BuyChips(1);
		}

		[Test]
		public void Play_BetOnXDiceRollX_WinsSixTimesBet([Range(1, 6, 1)] int x)
		{
			_player.Bet(1, x);
			var dice = new StubDice(x);

			_game.Play(dice);

			Assert.AreEqual(_player.Chips, 6);
		}

		[Test]
		public void Play_BetOnXDiceRollNotX_Loses([Range(1, 6, 1)] int x)
		{
			_player.Bet(1, x+1);
			var dice = new StubDice(x);

			_game.Play(dice);

			Assert.AreEqual(_player.Chips, 0);
		}
	}
}
