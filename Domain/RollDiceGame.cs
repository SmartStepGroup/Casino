using System;

namespace Domain
{
	public interface IDice
	{
		int Roll();
	}

	public class RandomDice : IDice
	{
		private readonly Random _dice = new Random();
		public int Roll()
		{
			return _dice.Next(1, 7);
		}
	}

	public class RollDiceGame
	{
		public Player Player { get; set; }

		public void Play(IDice dice)
		{
			var winningScore = dice.Roll();
			if (Player.CurrentBet.Score == winningScore)
			{
				Player.Win(Player.CurrentBet.Chips * 6);
			}
			else
			{
				Player.Lose();
			}
		}
	}
}