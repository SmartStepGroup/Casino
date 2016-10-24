using Domain;
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

      private const int WIN_COEF = 6;

      private RollDiceGame _rollDiceGame;

      private Player _player;

      private StubDice _stubDice;

      [SetUp]
      public void SetUp()
      {
         _stubDice = new StubDice(DEFAULT_DICE_RESULT);

         _rollDiceGame = new RollDiceGame(_stubDice);
         _player = new Player();
         _player.BuyChips(DEFAULT_BUY_CHIPS_VALUE);

         _rollDiceGame.Player = _player;
      }

      [Test]
      public void Play_PlayerDefaultWinBet_UseDice()
      {
         _player.Bet(DEFAULT_BET_CHIPS_VALUE, DEFAULT_WIN_BET_SCORE);

         _rollDiceGame.Play();

         Assert.AreEqual(1, _stubDice.CallCount);
      }

      [Test]
      public void Play_PlayerDefaultWinBet_PlayerChipsIsWinedChipsValue()
      {
         _player.Bet(DEFAULT_BET_CHIPS_VALUE, DEFAULT_WIN_BET_SCORE);

         _rollDiceGame.Play();

         Assert.AreEqual(DEFAULT_BET_CHIPS_VALUE * WIN_COEF, _player.Chips);
      }

      [Test]
      public void Play_PlayerDefaultLoseBet_PlayerLostChips()
      {
         _player.Bet(DEFAULT_BET_CHIPS_VALUE, DEFAULT_LOSE_BET_SCORE);

         _rollDiceGame.Play();

         Assert.AreEqual(DEFAULT_BUY_CHIPS_VALUE - DEFAULT_BET_CHIPS_VALUE, _player.Chips);
      }
   }
}