using System;
using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class RollDiceGameTests
	{
		private int AnyScore = 3;
		private int OneChip = 1;
		private int AnyChip = 3;


		[Test]
		public void GamePlay_PlayerWin_HasSixTimesMoreChips()
		{
			var game = CreateWinDiceStub(AnyScore);
			var player = new Player();
			player.BuyChips(AnyChip);
			player.Bet(chips: AnyChip, score: AnyScore);
			game.Player = player;

			game.Play();

			Assert.AreEqual(AnyChip*6, player.Chips);
			Assert.IsNull(player.CurrentBet);
		}

		[Test]
		public void GamePlay_PlayerWin_CallWin()
		{
			var game = CreateWinDiceStub(AnyScore);
			var player = CreateMockPlayerWithBet(game, AnyChip, AnyScore);

			game.Play();

			player.Verify(x => x.Win(AnyChip*6), Times.Once);
		}

		private Mock<Player> CreateMockPlayerWithBet(RollDiceGame game, int chip, int score)
		{
			var player = new Mock<Player>();
			player.SetupGet(_ => _.CurrentBet).Returns(new Bet(chips: chip, score: score));
			game.Player = player.Object;
			return player;
		}

		[Test]
		public void GamePlay_PlayerLose_HasNoChip()
		{
			var game = CreateLoseDiceStub();
			var player = new Player();
			player.BuyChips(AnyChip);
			player.Bet(chips: AnyChip, score: AnyScore);
			game.Player = player;

			game.Play();

			Assert.AreEqual(0, player.Chips);
			Assert.IsNull(player.CurrentBet);
		}


		[Test]
		public void GamePlay_PlayerLose_CallLose()
		{
			var game = CreateLoseDiceStub();
			var player = new Mock<Player>();
			player.SetupGet(_ => _.CurrentBet).Returns(new Bet(chips: AnyChip, score: AnyScore));
			game.Player = player.Object;

			game.Play();

			player.Verify(x => x.Lose(), Times.Once);
		}

		private static RollDiceGame CreateWinDiceStub(int winScore)
		{
			var dice = new Mock<IDice>();
			dice.Setup(_ => _.Roll()).Returns(winScore);
			var game = new RollDiceGame(dice.Object);
			return game;
		}

		private static RollDiceGame CreateLoseDiceStub()
		{
			var loseScore = -1;
			var dice = new Mock<IDice>();
			dice.Setup(_ => _.Roll()).Returns(loseScore);
			var game = new RollDiceGame(dice.Object);
			return game;
		}


		[Test]
		[Category("WTF")]
		public void CannotPlay_PlayerHasNoBet_NullReferenceException()
		{
			var winScore = 3;
			var game = new RollDiceGame(new DiceStub(winScore));
			var player = new Player();
			game.Player = player;

			Assert.Catch<NullReferenceException>(() => game.Play());

			Assert.AreEqual(0, player.Chips);
			Assert.IsNull(player.CurrentBet);
		}
		
	}
}
