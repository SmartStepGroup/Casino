namespace Domain
{
   public struct Bet
   {
      public Bet(int chips)
         :this()
      {
         Chips = chips;
      }

      public int Chips { get; private set; }
   }
}