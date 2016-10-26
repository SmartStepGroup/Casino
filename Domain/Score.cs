namespace Domain
{
   public struct Score
   {
      public Score(int number)
         : this()
      {
         Number = number;
      }

       public int Number { get; private set; }
   }
}