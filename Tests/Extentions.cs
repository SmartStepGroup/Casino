using Domain;

namespace Tests
{
   public static class Extentions
   {
      public static Chip chips(this int value)
      {
         return new Chip(value);
      }

      public static int score(this int value)
      {
         return value;
      }
   }
}