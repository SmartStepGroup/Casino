using Domain;

namespace Tests
{
   public static class TestExtension
   {
      public static Chip Chips(this int count)
      {
         return new Chip(count);
      }
   }
}