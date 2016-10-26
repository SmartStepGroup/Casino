using System;

namespace Domain.TDD
{
   public struct Chips
   {
      private Chips(int value)
      {
         if (value < 0)
            throw new ArgumentOutOfRangeException("value");

         Value = value;
      }

      public int Value { get; }

      public static Chips operator +(Chips left, Chips right)
      {
         return new Chips(left.Value + right.Value);
      }

      public static explicit operator Chips(int value)
      {
         return new Chips(value);
      }

      public static explicit operator int(Chips chips)
      {
         return chips.Value;
      }

      public static bool operator >(Chips left, Chips right)
      {
         return left.Value > right.Value;
      }

      public static bool operator <(Chips left, Chips right)
      {
         return left.Value < right.Value;
      }
   }
}