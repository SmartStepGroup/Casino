﻿using System;

namespace Domain
{
	public class Player
	{
		public int Chips { get; private set; }

		public bool IsInGame { get; private set; }

		public Bet CurrentBet { get; private set; }

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
			CurrentBet = bet;
		}
	}
}