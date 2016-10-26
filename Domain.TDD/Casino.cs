using System;

namespace Domain.TDD
{
   public class Casino
   {
      public Bet Bet(BetRequest betRequest)
      {
         if ((int) betRequest.Chips%5 != 0)
            throw new ArgumentException("betRequest");

         return new Bet(betRequest.Chips, betRequest.Score);
      }
   }
}