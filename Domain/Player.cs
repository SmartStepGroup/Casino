using System;
using System.Collections.Generic;

namespace Domain
{
	public class Player
	{
		public Player()
		{
			CurrentBet = new BetCombination();
		}

		public int Chips { get; private set; }

		public bool IsInGame { get; private set; }

		public BetCombination CurrentBet { get; private set; }

		public void Joins(RollDiceGame game)
		{
			if (IsInGame || (game.PlayerCount == 6))
			{
				throw new InvalidOperationException();
			}
			IsInGame = true;
			++game.PlayerCount;
		}

		public void LeaveGame()
		{
			if (!IsInGame)
			{
				throw new InvalidOperationException();
			}
			IsInGame = false;
		}

		public void BuyChips(int chips)
		{
			Chips += chips;
		}

		public void Bet(Bet bet)
		{
			if (bet.Chips > Chips)
			{
				throw new InvalidOperationException();
			}
			CurrentBet.Bets.Add(bet);
		}

		public void Win(int score)
		{
			//Chips += CurrentBet.GetPrize(score);
		}
	}

	public class BetCombination
{
		public BetCombination()
		{
			Bets = new List<Bet>();
		}

		public List<Bet> Bets { get; set; }
	}
}