namespace Domain
{
   public struct Bet
   {
      public Bet(uint chips)
         :this()
      {
         Chips = chips;
      }

      public uint Chips { get; private set; }
   }
}