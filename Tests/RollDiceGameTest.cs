using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class RollDiceGameTest
   {
      private const int DEFAULT_DICE_RESULT = 1;

      private const int DEFAULT_WIN_BET_SCORE = DEFAULT_DICE_RESULT;

      private const int DEFAULT_LOSE_BET_SCORE = 2;

      private RollDiceGame _rollDiceGame;

      private Player _player;

      private StubDice _stubDice;

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
         configurePlayerAndDice(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>());

         _rollDiceGame.Play();

         _diceStub.Verify(s => s.Roll(), Times.Once);
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
         configurePlayerAndDice(playerChips: It.IsAny<int>(), playerBetChips: playerBetChips, playerBetScore: It.IsAny<int>(), diceWinScore:It.IsAny<int>());

         _rollDiceGame.Play();

         _playerStub.Verify(_ => _.Win(playerBetChips * 6));
      }

      [Test]
      public void Play_PlayerDefaultWinBet_PlayerChipsIsWinedChipsValue()
      {
         configurePlayerAndDice(playerChips: It.IsAny<int>(), playerBetChips: It.IsAny<int>(), playerBetScore: DEFAULT_WIN_BET_SCORE, diceWinScore: DEFAULT_WIN_BET_SCORE);

         _rollDiceGame.Play();

         _playerStub.Verify(s => s.Win(It.IsAny<int>()), Times.Once);
      }

      [Test]
      public void Play_PlayerDefaultLoseBet_PlayerLostChips()
      {
         configurePlayerAndDice(playerChips: It.IsAny<int>(), playerBetChips: It.IsAny<int>(), playerBetScore: DEFAULT_LOSE_BET_SCORE, diceWinScore: DEFAULT_WIN_BET_SCORE);
         
         _rollDiceGame.Play();
         
         _playerStub.Verify(_ => _.Lose(), Times.Once);
      }

      

      private void configurePlayerAndDice(int playerChips, int playerBetChips, int playerBetScore, int diceWinScore)
      {
         _playerStub.Reset();
         _playerStub.SetupGet(_ => _.Chips).Returns(playerChips);
         _playerStub.SetupGet(_ => _.CurrentBet).Returns(new Bet(playerBetChips, playerBetScore));

         _diceStub.Reset();
         _diceStub.Setup(_ => _.Roll()).Returns(diceWinScore);
      }
   }
}