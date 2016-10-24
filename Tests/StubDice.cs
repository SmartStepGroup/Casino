using Domain;

namespace Tests
{
   public class StubDice : IDice
   {
      public StubDice(int result)
      {
         Result = result;
      }

      public int Result { get; set; }

      public int CallCount { get; private set; }

      int IDice.Roll()
      {
         CallCount++;

         return Result;
      }
   }
}