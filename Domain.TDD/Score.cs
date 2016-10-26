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

            Value = value;
        }

        public int Value { get; private set; }

        public static bool operator ==(Score left, Score right)
        {
            return right.Value == left.Value;
        }

        public static bool operator !=(Score left, Score right)
        {
            return right.Value != left.Value;
        }

        public static Score operator +(Score left, Score right)
        {
            return new Score(left.Value + right.Value);
        }

        public static Score operator -(Score left, Score right)
        {
            return new Score(left.Value - right.Value);
        }

        public static explicit operator Score(int value)
        {
            return new Score(value);
        }
    }
}