using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class GameBehaviorTest
   {
      private Mock<Player> player;
      private const int anyChips = 1;
      private const int playerScore = 2;

      [SetUp]
      public void Initialize()
      {
         player = new Mock<Player>();
         player.SetupGet(_ => _.CurrentBet).Returns(new Bet(anyChips, playerScore));
      }

      [Test]
      public void PlayerWins_CheckWinIsCalled()
      {
         var game = CreateGame(playerScore);
         player.Object.Join(game);

         game.Play();

         player.Verify(_ => _.Win(It.IsAny<int>()), Times.Once);
      }
      [Test]
      public void PlayerLoses_CheckLoseIsCalled()
      {
         var game = CreateGame(~playerScore);
         player.Object.Join(game);

         game.Play();

         player.Verify(_ => _.Lose(), Times.Once);
      }

      private static RollDiceGame CreateGame(int gameScore)
      {
         var diceMock = new Mock<IDice>();
         diceMock.Setup(m => m.Get()).Returns(gameScore);

         var game = new RollDiceGame(diceMock.Object);

         return game;
      }
   }
}