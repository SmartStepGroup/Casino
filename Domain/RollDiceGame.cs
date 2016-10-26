using System;

namespace Domain
{
    public class RollDiceGame
    {
        private const int _maxPlayers = 6;

        private int _playerCount;

        public int PlayerCount
        {
            get
            {
                return _playerCount;
            }
            set
            {
                if (_playerCount >= _maxPlayers)
                {
                    throw new InvalidOperationException();
                }
                _playerCount = value;
            }
        }
    }
}