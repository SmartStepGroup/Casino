using Domain;
using Moq;
using NUnit.Framework;

namespace Tests.DSL
{
   public static class IDSLPlayerExtension
   {
      public static IDSLPlayer BuyChips(this IDSLPlayer player, int playerChips)
      {
         player.PlayerStub.SetupGet(_ => _.Chips).Returns(playerChips);

         return player;
      }

      public static IDSLPlayer BuyChips(this IDSLPlayer player)
      {
         return player.BuyChips(It.IsAny<int>());
      }

      public static IDSLPlayer JoinGame(this IDSLPlayer player, IRollDiceGame game)
      {
         game.Player = player.PlayerStub.Object;

         return player;
      }

      public static IDSLPlayer LeftGame(this IDSLPlayer player, IRollDiceGame game)
      {
         game.Player = null;

         return player;
      }

      public static IDSLPlayer MakeBet(this IDSLPlayer player, int betChips, int betScore)
      {
         player.PlayerStub.SetupGet(_ => _.CurrentBet).Returns(new Bet(betChips, betScore));

         return player;
      }

      public static IDSLPlayer MakeBet(this IDSLPlayer player, int betScore)
      {
         return player.MakeBet(It.IsAny<int>(), betScore);
      }

      public static IDSLPlayer MakeBet(this IDSLPlayer player)
      {
         return player.MakeBet(It.IsAny<int>());
      }

      public static void CheckIsLost(this IDSLPlayer player)
      {
         player.PlayerStub.Verify(_ => _.Lose(), Times.Once);
      }

      public static void CheckIsWin(this IDSLPlayer player, int winnedChips)
      {
         player.PlayerStub.Verify(_ => _.Win(winnedChips), Times.Once());
      }

      public static void CheckIsWin(this IDSLPlayer player)
      {
         player.CheckIsWin(It.IsAny<int>());
      }

      public static void CheckIsNotInGame(this IDSLPlayer player, IRollDiceGame game)
      {
         Assert.IsNull(game.Player);
      }
   }
}