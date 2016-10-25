namespace Tests.DSL
{
   public static class Create
   {
      public static IDSLGame Game()
      {
         return new DSLGame();
      }

      public static IDSLPlayer Player()
      {
         return new DSLPlayer();
      }
   }
}