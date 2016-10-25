using Domain;

namespace Tests
{
   internal class DiceStub : IDice
   {
      private readonly int _diceValue;

      public DiceStub(int diceValue)
      {
         _diceValue = diceValue;
      }

      public int Roll()
      {
         return _diceValue;
      }
   }
}