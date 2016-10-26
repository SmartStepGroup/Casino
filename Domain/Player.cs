using System;
using System.Collections.Generic;
using Castle.Components.DictionaryAdapter;

namespace Domain
{
    public class Player
    {
        private const int _maxBetScore = 6;
        private RollDiceGame _game;

        public bool IsInGame { get; set; }
        public int CurrentChips { get; set; }
        public List<Bet> Bets { get; set; }

        public Player()
        {
            Bets = new List<Bet>();
        }

        public void Join(RollDiceGame game)
        {
            if (IsInGame)
            {
                throw new InvalidOperationException();
            }
            _game = game;
            game.Player = this;
            game.PlayerCount++;
            IsInGame = true;
        }

        public void LeaveGame()
        {
            if (!IsInGame)
            {
                throw new InvalidOperationException();
            }
            _game.Player = null;
            IsInGame = false;
        }

        public void BuyChips(int chips)
        {
            CurrentChips += chips;
        }

        public void Bet(int betChips, int score)
        {
            if (betChips % 5 != 0
                || CurrentChips < betChips
                || score > _maxBetScore)
            {
                throw new InvalidOperationException();
            }

            CurrentChips -= betChips;
            Bets.Add(new Bet(betChips, score));
        }
    }

    public class Bet
    {
        public int Chips { get; set; }
        public int Score { get; set; }

        public Bet(int chips, int score)
        {
            Chips = chips;
            Score = score;
        }
    }
}