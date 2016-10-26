namespace Domain.TDD
{
   public class BetRequest
   {
      public BetRequest(Chips chips, Score score)
      {
         Chips = chips;
         Score = score;
      }

      public Chips Chips { get; private set; }

      public Score Score { get; private set; }
   }
}