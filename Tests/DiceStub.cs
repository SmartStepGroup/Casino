using Domain;

namespace Tests
{
   internal class DiceStub : IDice
   {
      private readonly int _value;

      public DiceStub(int value)
      {
         _value = value;
      }

      public int Roll()
      {
         return _value;
      }
   }
}