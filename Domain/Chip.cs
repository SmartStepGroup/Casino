namespace Domain
{
   public struct Chip
   {
      public Chip(int count)
         : this()
      {
         Count = count;
      }

       public int Count { get; private set; }
   }
}