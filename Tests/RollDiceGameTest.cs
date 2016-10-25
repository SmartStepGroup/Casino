using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class RollDiceGameTest
   {
      private const int DEFAULT_DICE_RESULT = 1;

      private const int DEFAULT_BUY_CHIPS_VALUE = 1;

      private const int DEFAULT_WIN_BET_SCORE = DEFAULT_DICE_RESULT;

      private const int DEFAULT_LOSE_BET_SCORE = 2;

      private const int DEFAULT_BET_CHIPS_VALUE = 1;

      private RollDiceGame _rollDiceGame;

      private Player _player;

      private StubDice _stubDice;

      private Mock<IDice> _diceStub;

      private Mock<IPlayer> _playerStub;
      
      [Test]
      public void Play_PlayerDefaultWinBet_UseDice()
      {
         configurePlayerAndDice(DEFAULT_BET_CHIPS_VALUE, DEFAULT_WIN_BET_SCORE, It.IsAny<int>(), DEFAULT_WIN_BET_SCORE);

         _rollDiceGame.Play();

         _diceStub.Verify(s => s.Roll(), Times.Once);
      }

      [Test]
      [TestCase(1, 1, 1, 1 * 6)]
      [TestCase(2, 1, 1, 2 * 6)]
      [TestCase(0, 1, 1, 0 * 6)]
      [TestCase(4, 5, 5, 4 * 6)]
      [TestCase(3, 4, 4, 3 * 6)]
      public void Play_PlayerDefaultWinBet_PlayerChipsIsWinedChipsValue(int playerBetCHips, int playerBetScore, int diceWeinScore, int playerWinChips)
      {
         configurePlayerAndDice(playerBetCHips, playerBetScore, playerWinChips, diceWeinScore);

         _rollDiceGame.Play();

         _playerStub.Verify(s => s.Win(playerWinChips), Times.Once);
      }

      [Test]
      public void Play_PlayerDefaultLoseBet_PlayerLostChips()
      {
         _player = new Player();
         _player.BuyChips(DEFAULT_BUY_CHIPS_VALUE);
         _player.Bet(DEFAULT_BET_CHIPS_VALUE, DEFAULT_LOSE_BET_SCORE);
         _rollDiceGame = new RollDiceGame(new StubDice(DEFAULT_WIN_BET_SCORE));
         _player.Join(_rollDiceGame);

         _rollDiceGame.Play();

         Assert.AreEqual(DEFAULT_BUY_CHIPS_VALUE - DEFAULT_BET_CHIPS_VALUE, _player.Chips);
      }

      private void configurePlayerAndDice(int betChips, int betScore, int playerWinChips, int diceWinScore)
      {
         _diceStub = new Mock<IDice>();
         _playerStub = new Mock<IPlayer>();
         _stubDice = new StubDice(DEFAULT_DICE_RESULT);

         _rollDiceGame = new RollDiceGame(_diceStub.Object);
         _player = new Player();
         _player.BuyChips(DEFAULT_BUY_CHIPS_VALUE);

         _rollDiceGame.Player = _playerStub.Object;

         _playerStub.SetupGet(s => s.CurrentBet).Returns(new Bet(betChips, betScore));
         _playerStub.Setup(s => s.Win(playerWinChips));

         _diceStub.Setup(s => s.Roll()).Returns(diceWinScore);
      }
   }
}