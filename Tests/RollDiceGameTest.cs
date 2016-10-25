using System.Runtime.InteropServices;
using Domain;
using Moq;
using NUnit.Framework;
using Tests.DSL;

namespace Tests
{
   [TestFixture]
   public class RollDiceGameTest
   {
      private const int DEFAULT_DICE_RESULT = 1;

      private const int DEFAULT_WIN_BET_SCORE = DEFAULT_DICE_RESULT;

      private const int DEFAULT_LOSE_BET_SCORE = 2;

      private RollDiceGame _rollDiceGame;

      private Mock<IDice> _diceStub;

      private Mock<IPlayer> _playerStub;

      [SetUp]
      public void Setup()
      {
         _diceStub = new Mock<IDice>();
         _playerStub = new Mock<IPlayer>();

         _rollDiceGame = new RollDiceGame(_diceStub.Object)
         {
            Player = _playerStub.Object
         };
      }

      [Test]
      public void Play_PlayerDefaultWinBet_UseDice()
      {
         var game = Create.Game().WithWinScore();
         var player = Create.Player().BuyChips().JoinGame(game).MakeBet();

         game.Play();

         game.CheckIfUsedDiceOnce();
      }

      [Test]
      [TestCase(1)]
      [TestCase(2)]
      [TestCase(5)]
      [TestCase(10)]
      [TestCase(100)]
      [TestCase(1000)]
      public void Play_PlayerWinBet_PlayerWinSixSelfBet(int playerBetChips)
      {
         var game = Create.Game().WithWinScore(DEFAULT_WIN_BET_SCORE);
         var player = Create.Player().BuyChips().JoinGame(game).MakeBet(playerBetChips, DEFAULT_WIN_BET_SCORE);

         game.Play();

         player.CheckIsWin(playerBetChips * 6);
      }

      [Test]
      public void Play_PlayerInGemeWithWinScore_PlayerWins()
      {
         var game = Create.Game().WithWinScore(DEFAULT_WIN_BET_SCORE);
         var player = Create.Player().BuyChips().JoinGame(game).MakeBet(DEFAULT_WIN_BET_SCORE);

         game.Play();

         player.CheckIsWin();
      }

      [Test]
      public void Play_PlayerInGemeWithWrongScore_LoseGame()
      {
         var game = Create.Game().WithWinScore(DEFAULT_WIN_BET_SCORE);
         var player = Create.Player().BuyChips().JoinGame(game).MakeBet(DEFAULT_LOSE_BET_SCORE);

         game.Play();

         player.CheckIsLost();
      }

      [Test]
      public void Leave_PlayerInGame_LeavesGame()
      {
         var game = Create.Game();
         var player = Create.Player().JoinGame(game);

         player.LeftGame(game);

         player.CheckIsNotInGame(game);
      }
   }
}