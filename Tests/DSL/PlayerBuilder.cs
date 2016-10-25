using System;
using Domain;

namespace Tests.DSL
{
    public class PlayerBuilder
    {
        private int? _chipsCount;
        private RollDiceGame _game;

        public IPlayer Build()
        {
            return new Player();
        }

        public PlayerBuilder WithChips(int chipsCount)
        {
            if (_chipsCount.HasValue)
            {
                throw new InvalidOperationException("Cannot call twice.");
            }

            _chipsCount = chipsCount;

            return this;
        }

        public PlayerBuilder In(RollDiceGame game)
        {
            if (_game != null)
            {
                throw new InvalidOperationException("Cannot call twice.");
            }

            _game = game;

            return this;
        }

        public static implicit operator Player(PlayerBuilder playerBuilder)
        {
            Player player = new Player();

            if (playerBuilder._chipsCount.HasValue)
            {
                player.BuyChips(playerBuilder._chipsCount.Value);
            }

            if (playerBuilder._game != null)
            {
                player.Join(playerBuilder._game);
            }

            return player;
        }
    }
}