namespace Domain
{
   public struct Bet
   {
      public Bet(Chip chips, Score score)
         :this()
      {
         Chips = chips;
         Score = score;
      }

      public Chip Chips { get; private set; }

      public Score Score { get; private set; }
   }
}