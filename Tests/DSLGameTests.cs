using System.Dynamic;
using Castle.Core.Resource;
using Domain;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Tests
{
	[TestFixture]
	public class DSLGameTests
	{
		private int LuckyScore = 3;
		private int AnyChip = 3;
		private DslBuilder Create = new DslBuilder();

		[Test]
		public void GamePlay_PlayerWin_HasSixTimesMoreChips()
		{
			var player = Create.Player().WithBet(chips: AnyChip, score: LuckyScore).GetPlayer();
			var game = Create.Game().WithPlayer(player).WithLuckyDice(LuckyScore).GetGame();

			game.Play();

			Assert.AreEqual(AnyChip * 6, player.Chips);
			Assert.IsNull(player.CurrentBet);
		}
	}

	internal class DslBuilder
	{
		public PlayerBulder Player()
		{
			return new PlayerBulder();
		}
		public GameBulder Game()
		{
			return new GameBulder();
		}
	}
	
	internal class PlayerBulder
	{
		private Player _player;

		public PlayerBulder()
		{
			_player = new Player();
		}

		public PlayerBulder WithBet(int chips, int score)
		{
			_player.BuyChips(chips);
			_player.Bet(chips, score);
			return this;
		}

		public Player GetPlayer()
		{
			return _player;
		}
	}

	internal class GameBulder
	{	
		private RollDiceGame _game { get; set; }
		private Mock<IDice> _dice;
		public GameBulder()
		{
			_dice = new Mock<IDice>();
			_game = new RollDiceGame(_dice.Object);
		}
		
		public GameBulder WithLuckyDice(int winScore)
		{
			_dice.Setup(_ => _.Roll()).Returns(winScore);
			return this;
		}

		public GameBulder WithUnLuckyDice()
		{
			_dice.Setup(_ => _.Roll()).Returns(-1);
			return this;
		}

		public GameBulder WithPlayer(Player player)
		{
			_game.Player = player;
			return this;
		}

		public RollDiceGame GetGame()
		{
			return _game;
		}
	}
}