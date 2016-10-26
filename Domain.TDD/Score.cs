using System;

namespace Domain.TDD
{
    public struct Score
    {
        private Score(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("value");
            }
        }

        public static explicit operator Score(int value)
        {
            return new Score(value);
        }
    }
}