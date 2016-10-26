using Domain;

namespace Tests
{
   public static class TestExtension
   {
      public static Chip Chips(this int count)
      {
         return new Chip(count);
      }

      public static Score On(this int number)
      {
         return new Score(number);
      }
   }
}