using Moq;

namespace Tests.DSL
{
   public static class DSLGameExtension
   {
      public static IDSLGame WithWinScore(this IDSLGame dslGame, int diceWinScore)
      {
         dslGame.DiceMock.Setup(_ => _.Roll()).Returns(diceWinScore);

         return dslGame;
      }

      public static IDSLGame WithWinScore(this IDSLGame dslGame)
      {
         return dslGame.WithWinScore(It.IsAny<int>());
      }

      public static void CheckIfUsedDiceOnce(this IDSLGame dslGame)
      {
         dslGame.DiceMock.Verify(_ => _.Roll(), Times.Once());
      }
   }
}