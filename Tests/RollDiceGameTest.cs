// (c) Vladimir Krivopalov & Alexander Ivanov

using Domain;
using Moq;
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
			var mockPlayer = new Mock<Player>();
			mockPlayer.SetupGet(_ => _.CurrentBet).Returns(new Bet(1,x));
			_game.Player = mockPlayer.Object;
			var stubDice = Mock.Of<IDice>(_ =>  _.Roll() == x);

			_game.Play(stubDice);

			mockPlayer.Verify(_ => _.Win(6), Times.Once);
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
