// (c) Vladimir Krivopalov & Alexander Ivanov

using System;

using Domain;

using NUnit.Framework;

namespace Tests
{
	public class StubDice : IDice
	{
		private int _value;

		public StubDice(int value = 1)
		{
			_value = value;

		}

		public int Roll()
		{
			return _value;
		}
	}

	[TestFixture]
	public class PlayerTest
	{
		private Player _player;

		[SetUp]
		public void SetUp()
		{
			_player = new Player();
		}

		[Test]
		public void Constructor_ByDefault_ChipsEquals0()
		{
			Assert.AreEqual(_player.Chips, 0);
		}

		[Test]
		public void BuyChips_ArgumentEqualsX_IncreasesChipsByX([Values(1, 10, 1000)] int x)
		{
			_player.BuyChips(x);

			Assert.AreEqual(_player.Chips, x);
		}

		[Test]
		public void BuyChips_ArgumentNegative_ThrowArgumentException()
		{
			Assert.Catch<ArgumentException>(() => _player.BuyChips(-1));
		}

		[Test]
		public void Lose_CurrentBetEqualNull()
		{
			_player.Lose();

			Assert.AreEqual(_player.CurrentBet, null);
		}

		[Test]
		public void Win_ArgumentEquals1_IncreasesChips()
		{
			var prev_chips = _player.Chips;

			_player.Win(1);

			Assert.AreEqual(_player.Chips, prev_chips + 1);
		}

		[Test]
		public void Bet_ChipsNumberMoreThanCurrent_ThrowsArgumentException()
		{
			Assert.Catch<ArgumentException>(() => _player.Bet(_player.Chips + 1, score: 0));
		}
	}
}