using System;

namespace Domain
{
   public class RandomDice : IDice
   {
      private readonly Random _random = new Random();

      int IDice.Roll()
      {
         return _random.Next(1, 7);
      }
   }
}